using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Searchr.Core
{
    public static class Search
    {
        public static List<string> BinaryFiles = "exe,dll,pdb,bin,jpg,jpeg,gif,bmp,png,pack,nupkg,zip,7z,tar,gz,lz,bz2,rar,jar,cab,iso,img,mpg,mpeg,avi,mp4,aaf,mp3,wav,bik,mov,wmv".Split(',').Select(e => $"*.{e}").ToList();

        public static SearchResponse PerformSearch(SearchRequest request)
        {
            Regex FromWildcard(string pattern)
            {
                return new Regex("^" + Regex.Escape(pattern)
                                            .Replace("\\*", ".*")
                                            .Replace("\\?", ".") + "$",
                                 RegexOptions.IgnoreCase);
            }

            var response = new SearchResponse();
            var inputFiles = new BlockingCollection<FileInfo>();

            var includeFilePatterns = request.IncludeFileWildcards.Distinct().Select(FromWildcard).ToList();
            var excludeFileWildcards = request.ExcludeFileWildcards.ToList();

            if (request.ExcludeBinaryFiles)
            {
                excludeFileWildcards.AddRange(BinaryFiles);
            }

            var excludeFilePatterns = excludeFileWildcards.Distinct().Select(FromWildcard).ToList();

            // File list task
            Task.Run(() =>
            {
                try
                {
                    // Get some input
                    foreach (var file in EnumerateFiles(request, request.Directory, "*", request.DirectoryOption)
                                             .Select(f => new FileInfo(f))
                                             .Where(fi => ToBeSearched(request, fi, includeFilePatterns, excludeFilePatterns)))
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
                    response.SetError(new ApplicationException("Failed to enumerate files", ex));
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

        public static SearchResponse PerformFilter(SearchRequest request, IEnumerable<string> paths)
        {
            var response = new SearchResponse();
            var inputFiles = new BlockingCollection<FileInfo>();

            try
            {
                foreach (var path in paths)
                {
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

        private static IEnumerable<string> EnumerateFiles(SearchRequest request, string path, string searchPattern, SearchOption searchOption)
        {
            IEnumerable<string> files = null;
            IEnumerable<string> subdirs = null;

            if (request.Aborted)
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

        private static bool ToBeSearched(SearchRequest request,
                                         FileInfo fi,
                                         List<Regex> includePatterns,
                                         List<Regex> excludePatterns)
        {
            if (request.ExcludeHidden && fi.Attributes.HasFlag(FileAttributes.Hidden))
            {
                return false;
            }

            if (request.ExcludeSystem && fi.Attributes.HasFlag(FileAttributes.System))
            {
                return false;
            }

            if (excludePatterns.Any(pattern => pattern.IsMatch(fi.Name)))
            {
                return false;
            }

            if (includePatterns.Any())
            {
                return includePatterns.Any(pattern => pattern.IsMatch(fi.Name));
            }

            return true;
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
                            if (!file.Exists) continue;

                            var results = request.Algorithm.PerformSearch(request, file);

                            if (results.Match)
                            {
                                response.Results.Add(results);
                                Interlocked.Increment(ref response.Hits);
                            }
                            else
                            {
                                Interlocked.Increment(ref response.Misses);
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
