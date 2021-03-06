﻿using System;

namespace OmdbClientNet.Details
{
    public readonly struct ImdbId
    {
        public string Value { get; }

        public ImdbId(string imdbId)
        {
            if (string.IsNullOrWhiteSpace(imdbId))
            {
                throw new ArgumentNullException(nameof(imdbId));
            }

            Value = imdbId;
        }
    }
}