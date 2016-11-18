using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Searchr.Core
{
    public static class Search
    {
        public static SearchResponse PerformSearch(SearchRequest request)
        {
            var response = new SearchResponse();
            var inputFiles = new BlockingCollection<FileInfo>();
            var includeExtensionsLowered = request.IncludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).ToList();
            var excludeExtensionsLowered = request.ExcludeFileExtensions.Select(ext => ext.Trim().ToLower()).Select(ext => ext.StartsWith(".") ? ext : "." + ext).ToList();
            var excludeFolderNamesLowered = request.ExcludeFolderNames.Select(folder => String.Format(@"\{0}\", folder.ToLower())).ToList();
            var binaryFiles = ".exe,.dll,.pdb,.bin,.jpg,.gif,.bmp,.jpeg,.png,.pack,.nupkg,.zip,.7z".Split(',').ToList();

            // File list task
            Task.Run(() =>
            {
                // Get some input
                foreach (var file in Directory.EnumerateFiles(request.Directory, "*", request.DirectoryOption)
                                              .Select(f => new FileInfo(f))
                                              .Where(fi => ToBeSearched(request, fi, includeExtensionsLowered, excludeExtensionsLowered, excludeFolderNamesLowered, binaryFiles)))
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

                            if (results.TotalCount > 0)
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
