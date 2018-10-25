using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

namespace Searchr.Core
{
    internal class SearchParameters
    {
        public string Directory { get; private set; }
        public SearchOption DirectoryOption { get; private set; }
        public string SearchTerm { get; private set; }
        public bool MatchCase { get; private set; }
        public int ParallelSearches { get; private set; }
        public List<Regex> ExcludeFilePatterns { get; private set; }
        public List<Regex> IncludeFilePatterns { get; private set; }
        public List<string> ExcludeFolderNames { get; private set; }
        public bool ExcludeHidden { get; private set; }
        public bool ExcludeSystem { get; private set; }
        public bool ExcludeBinaryFiles { get; private set; }
        public bool SearchZipFiles { get; private set; }
        public bool SearchFileContents { get; private set; }
        public bool SearchFileName { get; private set; }
        public bool SearchFilePath { get; private set; }

        public CancellationToken CancellationToken;
        public SearchAlgorithm Algorithm;

        public static List<string> BinaryFiles = "exe,dll,pdb,bin,jpg,jpeg,gif,bmp,png,pack,nupkg,zip,7z,tar,gz,lz,bz2,rar,jar,cab,iso,img,mpg,mpeg,avi,mp4,aaf,mp3,wav,bik,mov,wmv,pdf,docx,doc,xlsx,xls,pptx,ppt,odt".Split(',').Select(e => $"*.{e}").ToList();

        internal static SearchParameters FromRequest(SearchRequest request)
        {
            var includeFilePatterns = request.IncludeFileWildcards.Distinct().Select(FromWildcard).ToList();
            var excludeFileWildcards = request.ExcludeFileWildcards.ToList();

            if (request.ExcludeBinaryFiles)
            {
                excludeFileWildcards.AddRange(BinaryFiles);
            }

            if (request.SearchZipFiles)
            {
                excludeFileWildcards.Remove("*.zip");
            }

            var excludeFilePatterns = excludeFileWildcards.Distinct().Select(FromWildcard).ToList();

            var parameters = new SearchParameters()
            {
                ExcludeFolderNames = request.ExcludeFolderNames,
                ExcludeFilePatterns = excludeFilePatterns,
                IncludeFilePatterns = includeFilePatterns,
                ExcludeHidden = request.ExcludeHidden,
                ExcludeSystem = request.ExcludeSystem,
                CancellationToken = request.CancellationToken,
                Algorithm = request.Algorithm,
                SearchTerm = request.SearchTerm,
                MatchCase = request.MatchCase,
                Directory = request.Directory,
                DirectoryOption = request.DirectoryOption,
                ExcludeBinaryFiles = request.ExcludeBinaryFiles,
                ParallelSearches = request.ParallelSearches,
                SearchFileContents = request.SearchFileContents,
                SearchFileName = request.SearchFileName,
                SearchFilePath = request.SearchFilePath,
                SearchZipFiles = request.SearchZipFiles
            };

            return parameters;
        }

        static Regex FromWildcard(string pattern)
        {
            return new Regex("^" + Regex.Escape(pattern)
                                        .Replace("\\*", ".*")
                                        .Replace("\\?", ".") + "$",
                             RegexOptions.IgnoreCase);
        }
    }
}
