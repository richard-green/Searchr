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
            var includeExtensionsLowered = request.IncludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).Distinct().ToList();
            var excludeExtensionsLowered = request.ExcludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).Distinct().ToList();
            var excludeFolderNamesLowered = request.ExcludeFolderNames.Select(folder => String.Format(@"\{0}\", folder.ToLower())).ToList();

            if (request.ExcludeBinaryFiles)
            {
                excludeExtensionsLowered.AddRange(BinaryFiles);
                excludeExtensionsLowered = excludeExtensionsLowered.Distinct().ToList();
            }

            // File list task
            Task.Run(() =>
            {
                try
                {
                    // Get some input
                    foreach (var file in EnumerateFiles(request.Directory, "*", request.DirectoryOption)
                                             .Select(f => new FileInfo(f))
                                             .Where(fi => ToBeSearched(request, fi, includeExtensionsLowered, excludeExtensionsLowered, excludeFolderNamesLowered)))
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
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
                finally
                {
                    // No more input
                    inputFiles.CompleteAdding();
                }
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

        private static IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption)
        {
            IEnumerable<string> files = null;
            IEnumerable<string> subdirs = null;

            try
            {
                files = Directory.EnumerateFiles(path, searchPattern);
            }
            catch (UnauthorizedAccessException)
            {
            }

            if (files != null)
                foreach (var file in files)
                    yield return file;

            if (searchOption == SearchOption.AllDirectories)
            {
                try
                {
                    subdirs = Directory.EnumerateDirectories(path, "*");
                }
                catch (UnauthorizedAccessException)
                {
                }
                
                if (subdirs != null)
                    foreach (var subdir in subdirs)
                        foreach (var file in EnumerateFiles(subdir, searchPattern, searchOption))
                            yield return file;
            }
        }

        private static bool ToBeSearched(SearchRequest request,
                                         FileInfo fi,
                                         List<string> includeExtensionsLowered,
                                         List<string> excludeExtensionsLowered,
                                         List<string> excludeFolderNamesLowered)
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
                try
                {
                    foreach (var file in inputFiles.GetConsumingEnumerable(request.CancellationToken))
                    {
                        try
                        {
                            if (request.Aborted)
                            {
                                break;
                            }
                            else
                            {
                                var results = request.Algorithm.PerformSearch(request, file);

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
                            response.SetError(ex);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                }
                catch (Exception ex)
                {
                    response.SetError(ex);
                }
            });
        }
    }
}
