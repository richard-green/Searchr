using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchr.Core
{
    public class SearchResponse
    {
        public BlockingCollection<SearchResult> Results { get; private set; }
        public int Hits;
        public int Misses;

        public SearchResponse()
        {
            this.Results = new BlockingCollection<SearchResult>();
        }
    }
}
