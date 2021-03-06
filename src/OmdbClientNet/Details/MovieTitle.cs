﻿using System;

namespace OmdbClientNet.Details
{
    public readonly struct MovieTitle
    {
        public string Value { get; }

        public MovieTitle(string movieTitle)
        {
            if (string.IsNullOrWhiteSpace(movieTitle))
            {
                throw new ArgumentNullException(nameof(movieTitle));
            }

            Value = movieTitle;
        }
    }
}