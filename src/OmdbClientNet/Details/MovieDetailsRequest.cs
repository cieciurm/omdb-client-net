using OmdbClientNet.Base;

namespace OmdbClientNet.Details
{
    public class MovieDetailsRequest : BaseRequest
    {
        /// <summary>
        /// A valid IMDb ID (e.g. tt1285016)
        /// </summary>
        public string ImdbId { get; }

        /// <summary>
        /// Movie title to search for.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Return short or full plot.
        /// </summary>
        public PlotType PlotType { get; set; } = PlotType.Short;

        /// <summary>
        /// Create a movie details request
        /// </summary>
        /// <param name="imdbId">A valid IMDb ID (e.g. tt1285016)</param>
        /// <param name="apiKey">API Key</param>
        public MovieDetailsRequest(string apiKey, ImdbId imdbId) : base(apiKey)
        {
            ImdbId = imdbId.Value;
        }

        /// <summary>
        /// Create a movie details request
        /// </summary>
        /// <param name="movieTitle">Movie title to search for.</param>
        /// <param name="apiKey">API Key</param>
        public MovieDetailsRequest(string apiKey, MovieTitle movieTitle) : base(apiKey)
        {
            Title = movieTitle.Value;
        }
    }
}
