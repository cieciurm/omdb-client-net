namespace OmdbClientNet.Base
{
    public abstract class BaseRequest
    {
        public string ApiKey { get; }

        /// <summary>
        /// Year of release.
        /// </summary>
        public int? Year { get; set; }

        /// <summary>
        /// Type of result to return.
        /// </summary>
        public ResultType? Type { get; set; }

        /// <summary>
        /// API version (reserved for future use).
        /// </summary>
        public int Version { get; set; }

        protected BaseRequest(string apiKey)
        {
            ApiKey = apiKey;
        }
    }
}
