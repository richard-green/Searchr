using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Searchr.Core
{
    public class SearchRequest
    {
        public string Directory { get; set; }
        public SearchOption DirectoryOption { get; set; }
        public string SearchTerm { get; set; }
        public SearchMethod SearchMethod { get; set; } = SearchMethod.SingleLine;
        public bool MatchCase { get; set; }
        public int ParallelSearches { get; set; }
        public IList<string> ExcludeFileExtensions { get; set; }
        public IList<string> IncludeFileExtensions { get; set; }
        public IList<string> ExcludeFolderNames { get; set; }
        public bool ExcludeHidden { get; set; }
        public bool ExcludeSystem { get; set; }
        public bool ExcludeBinaryFiles { get; set; }
        public bool SearchFileContents { get; set; }
        public bool SearchFileName { get; set; }
        public bool SearchFilePath { get; set; }
        public bool Aborted { get; private set; }

        private Lazy<SearchAlgorithm> algorithm;
        [JsonIgnore]
        public SearchAlgorithm Algorithm => algorithm.Value;

        private CancellationTokenSource CancellationSource { get; set; }
        [JsonIgnore]
        public CancellationToken CancellationToken => CancellationSource.Token;

        public SearchRequest()
        {
            this.Directory = null;
            this.DirectoryOption = SearchOption.AllDirectories;
            this.SearchTerm = null;
            this.SearchMethod = SearchMethod.SingleLine;
            this.MatchCase = false;
            this.ParallelSearches = 4;
            this.ExcludeFileExtensions = new List<string>();
            this.IncludeFileExtensions = new List<string>();
            this.ExcludeFolderNames = new List<string>();
            this.ExcludeHidden = false;
            this.ExcludeSystem = false;
            this.ExcludeBinaryFiles = false;
            this.SearchFileContents = true;
            this.SearchFileName = false;
            this.SearchFilePath = false;
            this.Aborted = false;
            this.CancellationSource = new CancellationTokenSource();

            this.algorithm = new Lazy<SearchAlgorithm>(LoadAlgorithm);
        }

        public void Abort()
        {
            Aborted = true;
            this.CancellationSource.Cancel();
        }

        private SearchAlgorithm LoadAlgorithm()
        {
            switch (SearchMethod)
            {
                case SearchMethod.SingleLine: return SearchAlgorithm.SingleLine;
                case SearchMethod.SingleLineRegex: return SearchAlgorithm.SingleLineRegex;
                default: throw new NotImplementedException($"Algorithm for Search Method {SearchMethod} has not been implemented");
            }
        }
    }
}
