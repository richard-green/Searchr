using System;
using System.IO;
using System.Text.RegularExpressions;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;

namespace Searchr.Core
{
    internal abstract class SearchAlgorithm
    {
        public static SearchAlgorithm SingleLine = new TextSearchMethod();
        public static SearchAlgorithm SingleLineRegex = new RegexSearchMethod();

        Func<string, bool> match;

        public IEnumerable<SearchResult> PerformSearch(SearchParameters parameters, FileInfo file)
        {
            match = CreateMatcher(parameters);

            foreach (var result in PerformSearch(parameters, file, () => file.OpenRead()))
            {
                yield return result;
            }
        }

        private IEnumerable<SearchResult> PerformSearch(SearchParameters parameters, FileInfo file, Func<Stream> open)
        {
            SearchResult results = new SearchResult(file);

            if (parameters.SearchFileName && match(file.Name))
            {
                results.Match = true;
            }

            if (parameters.SearchFilePath && match(file.FullName))
            {
                results.Match = true;
            }

            if (parameters.SearchZipFiles && file.Extension == ".zip")
            {
                using (var stream = open())
                using (var archive = new ZipArchive(stream))
                {
                    foreach (var entry in archive.Entries.Where(e => e.Length > 0))
                    {
                        if (parameters.CancellationToken.IsCancellationRequested)
                        {
                            break;
                        }

                        var fileEntry = new FileInfo(Path.Combine(file.FullName, entry.FullName.Replace('/', '\\')));

                        if (Search.MatchesFilePatterns(parameters, fileEntry))
                        {
                            foreach (var result in PerformSearch(parameters, fileEntry, () => entry.Open()))
                            {
                                yield return result;
                            }
                        }
                    }
                }
            }
            else if (parameters.SearchFileContents)
            {
                using (var stream = open())
                using (var reader = new StreamReader(stream))
                {
                    SearchStream(parameters, results, match, reader);                    
                }
            }

            if (results.Match)
            {
                yield return results;
            }
        }

        private static void SearchStream(SearchParameters parameters, SearchResult results, Func<string, bool> match, StreamReader reader)
        {
            int lineNumber = 1;
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                if (parameters.CancellationToken.IsCancellationRequested)
                {
                    break;
                }

                if (match(line))
                {
                    results.TotalCount++;
                    results.LineNumbers.Add(lineNumber);
                }

                lineNumber++;
            }

            if (results.TotalCount > 0) results.Match = true;
        }

        public abstract Func<string, bool> CreateMatcher(SearchParameters parameters);

        private class TextSearchMethod : SearchAlgorithm
        {
            public override Func<string, bool> CreateMatcher(SearchParameters parameters)
            {
                return value => value.IndexOf(parameters.SearchTerm, parameters.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0;
            }
        }

        private class RegexSearchMethod : SearchAlgorithm
        {
            public override Func<string, bool> CreateMatcher(SearchParameters parameters)
            {
                Regex exp = new Regex(parameters.SearchTerm, parameters.MatchCase ? RegexOptions.None : RegexOptions.IgnoreCase);

                return value => exp.IsMatch(value);
            }
        }
    }
}
