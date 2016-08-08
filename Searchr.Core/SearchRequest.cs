using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Searchr.Core
{
    public class SearchRequest
    {
        public string Directory { get; set; }
        public SearchOption DirectoryOption { get; set; }
        public string SearchTerm { get; set; }
        public string ReplaceTerm { get; set; }
        public SearchMethod Method { get; set; }
        public bool MatchCase { get; set; }
        public bool MatchWholeWordOnly { get; set; }
        public int ParallelSearches { get; set; }
        public IList<string> ExcludeFileExtensions { get; set; }
        public IList<string> IncludeFileExtensions { get; set; }
        public IList<string> ExcludeFolderNames { get; set; }
        public bool ExcludeHidden { get; set; }
        public bool ExcludeSystem { get; set; }
        public bool Aborted { get; private set; }

        public SearchRequest()
        {
            this.Directory = null;
            this.DirectoryOption = SearchOption.AllDirectories;
            this.SearchTerm = null;
            this.ReplaceTerm = null;
            this.Method = SearchMethod.SingleLine;
            this.MatchCase = false;
            this.MatchWholeWordOnly = false;
            this.ParallelSearches = 4;
            this.ExcludeFileExtensions = new List<string>();
            this.IncludeFileExtensions = new List<string>();
            this.ExcludeFolderNames = new List<string>();
            this.ExcludeHidden = false;
            this.ExcludeSystem = false;
            this.Aborted = false;
        }

        public void Abort()
        {
            Aborted = true;
        }
    }
}
