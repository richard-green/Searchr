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
            var includeExtensionsLowered = request.IncludeFileExtensions.Select(ext => ext.ToLower());
            var excludeExtensionsLowered = request.ExcludeFileExtensions.Select(ext => ext.ToLower());
            var excludeFolderNamesLowered = request.ExcludeFolderNames.Select(folder => String.Format(@"\{0}\", folder.ToLower()));

            // File list task
            Task.Run(() =>
            {
                // Get some input
                foreach (var file in Directory.EnumerateFiles(request.Directory, "*", request.DirectoryOption)
                                              .Select((f) => new FileInfo(f))
                                              .Where((fi) =>
                                              {
                                                  if (excludeFolderNamesLowered.Any(folder => fi.FullName.ToLower().IndexOf(folder) > 0))
                                                  {
                                                      return false;
                                                  }

                                                  if (includeExtensionsLowered.Any())
                                                  {
                                                      return fi.Extension.ToLower().InList(includeExtensionsLowered);
                                                  }
                                                  else
                                                  {
                                                      return fi.Extension.ToLower().InList(excludeExtensionsLowered) == false;
                                                  }
                                              }))
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
