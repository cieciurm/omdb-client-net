using System;

namespace OmdbClientNet.Details
{
    public readonly struct MovieTittle
    {
        public string Value { get; }

        public MovieTittle(string movieTitle)
        {
            if (string.IsNullOrWhiteSpace(movieTitle))
            {
                throw new ArgumentNullException(nameof(movieTitle));
            }

            Value = movieTitle;
        }
    }
}