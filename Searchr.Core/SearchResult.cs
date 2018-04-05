using System.Collections.Generic;
using System.IO;

namespace Searchr.Core
{
    public class SearchResult
    {
        public FileInfo File { get; set; }
        public bool Match { get; set; }
        public int TotalCount { get; set; }
        public List<int> LineNumbers { get; set; }

        public SearchResult(FileInfo File)
        {
            this.File = File;
            this.LineNumbers = new List<int>();
        }
    }
}
