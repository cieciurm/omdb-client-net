﻿using System.Text;
using OmdbClientNet.Base;
using OmdbClientNet.Details;
using OmdbClientNet.Search;

namespace OmdbClientNet
{
    internal class OmdbApiUrlBuilder
    {
        public const string Url = "http://www.omdbapi.com";

        private readonly StringBuilder _sb = new StringBuilder();

        public OmdbApiUrlBuilder(string apiKey, string baseAddress = null)
        {
            _sb.Append(baseAddress ?? Url);
            _sb.Append($"?apikey={apiKey}");
        }

        public OmdbApiUrlBuilder WithSearchRequest(SearchMovieRequest searchMovieRequest)
            => WithSearch(searchMovieRequest.Search)
                .WithResultType(searchMovieRequest.Type)
                .WithYear(searchMovieRequest.Year)
                .WithPage(searchMovieRequest.Page);

        public OmdbApiUrlBuilder WithDetailsRequest(MovieDetailsRequest movieDetailsRequest)
            => WithImdbId(movieDetailsRequest.ImdbId)
                .WithResultType(movieDetailsRequest.Type)
                .WithPlotType(movieDetailsRequest.PlotType)
                .WithYear(movieDetailsRequest.Year);
        
        public string Build() => _sb.ToString();

        private OmdbApiUrlBuilder WithSearch(string search)
        {
            _sb.Append($"&s={search}");

            return this;
        }

        private OmdbApiUrlBuilder WithImdbId(string imdbId)
        {
            _sb.Append($"&i={imdbId}");

            return this;
        }

        private OmdbApiUrlBuilder WithPlotType(PlotType plotType)
        {
            _sb.Append($"&plot={plotType.ToString().ToLower()}");

            return this;
        }

        private OmdbApiUrlBuilder WithResultType(ResultType? resultType)
        {
            if (resultType.HasValue)
            {
                _sb.Append($"&type={resultType.ToString().ToLower()}");
            }

            return this;
        }

        private OmdbApiUrlBuilder WithPage(int page)
        {
            _sb.Append($"&p={page}");

            return this;
        }

        private OmdbApiUrlBuilder WithYear(int? year)
        {
            if (year.HasValue)
            {
                _sb.Append($"&y={year}");
            }

            return this;
        }
    }
}
