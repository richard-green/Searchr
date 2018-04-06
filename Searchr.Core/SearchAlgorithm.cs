using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Searchr.Core
{
    public abstract class SearchAlgorithm
    {
        public static SearchAlgorithm SingleLine = new LineSearchMethod();
        public static SearchAlgorithm SingleLineRegex = new RegexLineSearchMethod();

        public abstract SearchResult PerformSearch(SearchRequest request, FileInfo file);

        private class LineSearchMethod : SearchAlgorithm
        {
            public override SearchResult PerformSearch(SearchRequest request, FileInfo file)
            {
                SearchResult results = new SearchResult(file);

                bool match(string value)
                {
                    return value.IndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0;
                }

                if (request.SearchFileName && match(file.Name))
                {
                    results.Match = true;
                }

                if (request.SearchFilePath && match(file.FullName))
                {
                    results.Match = true;
                }

                if (request.SearchFileContents)
                {
                    int lineNumber = 1;
                    string line;

                    using (var fileStream = new StreamReader(file.OpenRead()))
                    {
                        while ((line = fileStream.ReadLine()) != null)
                        {
                            if (request.Aborted)
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
                    }
                }

                if (results.TotalCount > 0) results.Match = true;

                return results;
            }
        }

        private class RegexLineSearchMethod : SearchAlgorithm
        {
            public override SearchResult PerformSearch(SearchRequest request, FileInfo file)
            {
                SearchResult results = new SearchResult(file);
                Regex exp = new Regex(request.SearchTerm, request.MatchCase ? RegexOptions.None : RegexOptions.IgnoreCase);

                if (request.SearchFileName && exp.IsMatch(file.Name))
                {
                    results.Match = true;
                }

                if (request.SearchFilePath && exp.IsMatch(file.FullName))
                {
                    results.Match = true;
                }

                if (request.SearchFileContents)
                {
                    int lineNumber = 1;
                    string line;

                    using (var fileStream = new StreamReader(file.OpenRead()))
                    {
                        while ((line = fileStream.ReadLine()) != null)
                        {
                            if (request.Aborted)
                            {
                                break;
                            }

                            if (exp.IsMatch(line))
                            {
                                results.TotalCount++;
                                results.LineNumbers.Add(lineNumber);
                            }

                            lineNumber++;
                        }
                    }
                }

                if (results.TotalCount > 0) results.Match = true;

                return results;
            }
        }
    }
}
