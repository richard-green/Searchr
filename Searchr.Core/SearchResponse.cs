using System.Collections.Concurrent;

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
