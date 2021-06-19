using System.Collections.Generic;
using System.Text.Json.Serialization;
using OmdbClientNet.Base;

namespace OmdbClientNet.Details
{
    public class MovieDetailsResponse : BaseResponse
    {
        public string Title { get; set; }

        public string Year { get; set; }

        public string Rated { get; set; }

        public string Released { get; set; }

        public string Runtime { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Writer { get; set; }

        public string Actors { get; set; }

        public string Plot { get; set; }

        public string Language { get; set; }

        public string Country { get; set; }

        public string Awards { get; set; }

        public string Poster { get; set; }

        [JsonPropertyName("imdbID")]
        public string ImdbId { get; set; }

        public string ImdbRating { get; set; }

        public string ImdbVotes { get; set; }

        public IEnumerable<Rating> Ratings = new List<Rating>();
    }

    public class Rating
    {
        public string Source { get; set; }

        public string Value { get; set; }
    }
}
