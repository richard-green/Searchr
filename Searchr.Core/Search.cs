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
        public static SearchResponse PerformSearch(SearchRequest request)
        {
            var response = new SearchResponse();
            var inputFiles = new BlockingCollection<FileInfo>();

            var parameters = SearchParameters.FromRequest(request);

            // File list task
            Task.Run(() =>
            {
                try
                {
                    // Get some input
                    foreach (var file in EnumerateFiles(parameters, parameters.Directory, "*", parameters.DirectoryOption)
                                            .Select(f => new FileInfo(f))
                                            .Where(fi => CheckAttributes(parameters, fi) && MatchesFilePatterns(parameters, fi)))
                    {
                        if (parameters.CancellationToken.IsCancellationRequested)
                        {
                            break;
                        }

                        inputFiles.Add(file);
                    }
                }
                catch (Exception ex)
                {
                    response.SetError(new ApplicationException("Failed to enumerate files", ex));
                }
                finally
                {
                    // No more input
                    inputFiles.CompleteAdding();
                }
            });

            // File contents search tasks
            Task.WhenAll(Enumerable.Range(0, Math.Max(parameters.ParallelSearches, 1))
                                   .Select((i) => CreateSearchTask(parameters, inputFiles, response)))
                .ContinueWith((task) =>
            {
                // Output finished
                response.Results.CompleteAdding();
            });

            // Return response immediately
            return response;
        }

        public static SearchResponse PerformFilter(SearchRequest request, IEnumerable<string> paths)
        {
            var response = new SearchResponse();

            var parameters = SearchParameters.FromRequest(request);

            var inputFiles = new BlockingCollection<FileInfo>();

            try
            {
                foreach (var path in paths)
                {
                    if (parameters.CancellationToken.IsCancellationRequested)
                    {
                        break;
                    }

                    inputFiles.Add(new FileInfo(path));
                }
            }
            catch (Exception ex)
            {
                response.SetError(new ApplicationException("Failed to enumerate files", ex));
            }
            finally
            {
                // No more input
                inputFiles.CompleteAdding();
            }

            // File contents search tasks
            Task.WhenAll(Enumerable.Range(0, Math.Max(parameters.ParallelSearches, 1))
                                   .Select((i) => CreateSearchTask(parameters, inputFiles, response)))
                .ContinueWith((task) =>
                {
                    // Output finished
                    response.Results.CompleteAdding();
                });

            // Return response immediately
            return response;
        }

        private static IEnumerable<string> EnumerateFiles(SearchParameters request, string path, string searchPattern, SearchOption searchOption)
        {
            IEnumerable<string> files = null;
            IEnumerable<string> subdirs = null;

            if (request.CancellationToken.IsCancellationRequested)
            {
                yield break;
            }

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
                    subdirs = Directory.EnumerateDirectories(path);
                }
                catch (UnauthorizedAccessException)
                {
                }

                if (subdirs != null)
                    foreach (var subdir in subdirs.Where(s => !request.ExcludeFolderNames.Any(exc => s.EndsWith(exc, StringComparison.CurrentCultureIgnoreCase) &&
                                                                                                     s.LastIndexOf('\\') == s.Length - exc.Length - 1))
                                                  .Where(s =>
                                                  {
                                                      var dir = new DirectoryInfo(s);
                                                      return !(request.ExcludeHidden && dir.Attributes.HasFlag(FileAttributes.Hidden)) &&
                                                             !(request.ExcludeSystem && dir.Attributes.HasFlag(FileAttributes.System));
                                                  }))
                        foreach (var file in EnumerateFiles(request, subdir, searchPattern, searchOption))
                            yield return file;
            }
        }

        internal static bool CheckAttributes(SearchParameters request,
                                             FileInfo fi)
        {
            if (request.ExcludeHidden && fi.Attributes.HasFlag(FileAttributes.Hidden))
            {
                return false;
            }

            if (request.ExcludeSystem && fi.Attributes.HasFlag(FileAttributes.System))
            {
                return false;
            }

            return true;
        }

        internal static bool MatchesFilePatterns(SearchParameters request,
                                             FileInfo fi)
        {
            if (request.IncludeFilePatterns.Any())
            {
                return request.IncludeFilePatterns.Any(pattern => pattern.IsMatch(fi.Name));
            }
            else
            {
                return request.ExcludeFilePatterns.Any(pattern => pattern.IsMatch(fi.Name)) == false;
            }
        }

        private static Task CreateSearchTask(SearchParameters parameters, BlockingCollection<FileInfo> inputFiles, SearchResponse response)
        {
            return Task.Run(() =>
            {
                try
                {
                    foreach (var file in inputFiles.GetConsumingEnumerable(parameters.CancellationToken))
                    {
                        try
                        {
                            foreach (var result in parameters.Algorithm.PerformSearch(parameters, file))
                            {
                                if (result.Match)
                                {
                                    response.Results.Add(result);
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
                            response.SetError(new ApplicationException("Failed to process file", ex));
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
