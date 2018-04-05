using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Searchr.Core
{
    public abstract class SearchMethod
    {
        public static SearchMethod SingleLine = new LineSearchMethod();
        public static SearchMethod SingleLineRegex = new RegexLineSearchMethod();

        public abstract SearchResult PerformSearch(SearchRequest request, FileInfo file);

        private class LineSearchMethod : SearchMethod
        {
            public override SearchResult PerformSearch(SearchRequest request, FileInfo file)
            {
                SearchResult results = new SearchResult(file);

                if (request.SearchFileName)
                {
                    if (file.Name.LastIndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        results.Match = true;
                    }
                }

                if (request.SearchFilePath)
                {
                    if (file.FullName.LastIndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        results.Match = true;
                    }
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

                            if (line.LastIndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0)
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

        private class RegexLineSearchMethod : SearchMethod
        {
            public override SearchResult PerformSearch(SearchRequest request, FileInfo file)
            {
                SearchResult results = new SearchResult(file);

                if (request.SearchFileName)
                {
                    if (file.Name.LastIndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        results.Match = true;
                    }
                }

                if (request.SearchFilePath)
                {
                    if (file.FullName.LastIndexOf(request.SearchTerm, request.MatchCase ? StringComparison.CurrentCulture : StringComparison.CurrentCultureIgnoreCase) >= 0)
                    {
                        results.Match = true;
                    }
                }

                if (request.SearchFileContents)
                {
                    int lineNumber = 1;
                    string line;
                    Regex exp = new Regex(request.SearchTerm, request.MatchCase ? RegexOptions.None : RegexOptions.IgnoreCase);

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
