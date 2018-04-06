using System;
using System.Collections.Concurrent;

namespace Searchr.Core
{
    public class SearchResponse
    {
        public BlockingCollection<SearchResult> Results { get; private set; }
        public int Hits;
        public int Misses;
        public Exception Error { get; private set; }

        public SearchResponse()
        {
            this.Results = new BlockingCollection<SearchResult>();
        }

        public void SetError(Exception ex)
        {
            this.Error = ex;
        }
    }
}
