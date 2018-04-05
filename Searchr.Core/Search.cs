using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Searchr.Core
{
    public static class Search
    {
        public static List<string> BinaryFiles = "exe,dll,pdb,bin,jpg,jpeg,gif,bmp,png,pack,nupkg,zip,7z,tar,gz,lz,bz2,rar,jar,cab,iso,img,mpg,mpeg,avi,mp4,aaf,mp3,wav,bik,mov,wmv".Split(',').Select(e => $".{e}").ToList();

        public static SearchResponse PerformSearch(SearchRequest request)
        {
            var response = new SearchResponse();
            var inputFiles = new BlockingCollection<FileInfo>();
            var includeExtensionsLowered = request.IncludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).ToList();
            var excludeExtensionsLowered = request.ExcludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).ToList();
            var excludeFolderNamesLowered = request.ExcludeFolderNames.Select(folder => String.Format(@"\{0}\", folder.ToLower())).ToList();

            // File list task
            Task.Run(() =>
            {
                // Get some input
                foreach (var file in Directory.EnumerateFiles(request.Directory, "*", request.DirectoryOption)
                                              .Select(f => new FileInfo(f))
                                              .Where(fi => ToBeSearched(request, fi, includeExtensionsLowered, excludeExtensionsLowered, excludeFolderNamesLowered, BinaryFiles)))
                {
                    if (request.Aborted)
                    {
                        break;
                    }
                    else
                    {
                        inputFiles.Add(file);
                    }
                }

                // No more input
                inputFiles.CompleteAdding();
            });

            // File contents search tasks
            Task.WhenAll(Enumerable.Range(0, Math.Max(request.ParallelSearches, 1))
                                   .Select((i) => CreateSearchTask(request, inputFiles, response)))
                .ContinueWith((task) =>
            {
                // Output finished
                response.Results.CompleteAdding();
            });

            // Return response immediately
            return response;
        }

        private static bool ToBeSearched(SearchRequest request,
                                         FileInfo fi,
                                         List<string> includeExtensionsLowered,
                                         List<string> excludeExtensionsLowered,
                                         List<string> excludeFolderNamesLowered,
                                         List<string> binaryFiles)
        {
            if (request.ExcludeHidden && fi.Attributes.HasFlag(FileAttributes.Hidden))
            {
                return false;
            }

            if (request.ExcludeSystem && fi.Attributes.HasFlag(FileAttributes.System))
            {
                return false;
            }

            if (excludeFolderNamesLowered.Any(folder => fi.FullName.ToLower().IndexOf(folder) > 0))
            {
                return false;
            }

            var extension = fi.Extension.ToLower();

            if (request.ExcludeBinaryFiles && extension.InList(binaryFiles))
            {
                return false;
            }

            if (includeExtensionsLowered.Any())
            {
                return extension.InList(includeExtensionsLowered);
            }
            else
            {
                return extension.InList(excludeExtensionsLowered) == false;
            }
        }

        private static Task CreateSearchTask(SearchRequest request, BlockingCollection<FileInfo> inputFiles, SearchResponse response)
        {
            return Task.Run(() =>
            {
                foreach (var file in inputFiles.GetConsumingEnumerable())
                {
                    try
                    {
                        if (request.Aborted)
                        {
                            break;
                        }
                        else
                        {
                            var results = request.Method.PerformSearch(request, file);

                            if (results.Match)
                            {
                                response.Results.Add(results);
                                Interlocked.Increment(ref response.Hits);
                            }
                            else
                            {
                                Interlocked.Increment(ref response.Hits);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            });
        }
    }
}
