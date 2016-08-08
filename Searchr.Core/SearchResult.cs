using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchr.Core
{
    public class SearchResult
    {
        public FileInfo File { get; set; }
        public int TotalCount { get; set; }
        public List<int> LineNumbers { get; set; }

        public SearchResult(FileInfo File)
        {
            this.File = File;
            this.LineNumbers = new List<int>();
        }
    }
}
