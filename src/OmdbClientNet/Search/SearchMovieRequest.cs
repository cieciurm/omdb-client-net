using OmdbClientNet.Base;

namespace OmdbClientNet.Search
{
    public class SearchMovieRequest : BaseRequest
    {
        /// <summary>
        /// Movie title to search for.
        /// </summary>
        public string Search { get; }

        /// <summary>
        /// Page number to return.
        /// </summary>
        public int Page { get; set; } = 1;

        public SearchMovieRequest(string apiKey, string searchPhrase) : base(apiKey)
        {
            Search = searchPhrase;
        }
    }
}
