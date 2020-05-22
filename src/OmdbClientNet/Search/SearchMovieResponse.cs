using System.Collections.Generic;
using System.Diagnostics;
using OmdbClientNet.Base;

namespace OmdbClientNet.Search
{
    public class SearchMovieResponse : BaseResponse
    {
        public IEnumerable<SearchMovie> Search { get; set; } = new List<SearchMovie>();
    }

    [DebuggerDisplay("{Title} - {Year}")]
    public class SearchMovie
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string ImdbId { get; set; }

        public string Type { get; set; }

        public string Poster { get; set; }
    }
}
