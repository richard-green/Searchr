using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

                return results;
            }
        }

        private class RegexLineSearchMethod : SearchMethod
        {
            public override SearchResult PerformSearch(SearchRequest request, FileInfo file)
            {
                SearchResult results = new SearchResult(file);
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

                return results;
            }
        }
    }
}
