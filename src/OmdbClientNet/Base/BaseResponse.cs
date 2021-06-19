using System;
using System.Text.Json.Serialization;

namespace OmdbClientNet.Base
{
    public abstract class BaseResponse
    {
        public string Response { get; set; }

        public bool ResponseBool => Convert.ToBoolean(Response);

        [JsonPropertyName("totalResults")]
        public string TotalResults { get; set; }

        public int TotalResultsInt => Convert.ToInt32(TotalResults);
    }
}
