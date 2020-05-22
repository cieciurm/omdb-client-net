using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using OmdbClientNet.Details;
using OmdbClientNet.Search;
using OmdbClientNet.Tests.Common;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class CombinedMovieTests : IClassFixture<OmdbClassFixture>
    {
        private readonly HttpMessageInvoker _client;
        private readonly OmdbSettings _omdbSettings;
        private readonly Func<string, SearchMovieResponse> _deserializeSearchResponse;
        private readonly Func<string, MovieDetailsResponse> _deserializeDetailsResponse;

        public CombinedMovieTests(OmdbClassFixture omdbClassFixture)
        {
            _client = omdbClassFixture.Client;
            _omdbSettings = omdbClassFixture.OmdbSettings;
            _deserializeSearchResponse = omdbClassFixture.DeserializeObject<SearchMovieResponse>;
            _deserializeDetailsResponse = omdbClassFixture.DeserializeObject<MovieDetailsResponse>;
        }

        [Fact]
        public async Task SearchMoviesAndGetMovieDetails_PropertiesShouldMatch()
        {
            // Arrange & Act
            var searchRequest = new SearchMovieRequest(_omdbSettings.ApiKey, "Batman");

            var searchResults = await _client.SearchMovies(searchRequest, _deserializeSearchResponse);
            var searchResult = searchResults.Search.ToList()[0];

            var detailsRequest = new MovieDetailsRequest(_omdbSettings.ApiKey, searchResult.ImdbId);

            var detailsResult = await _client.GetMovieDetails(detailsRequest, _deserializeDetailsResponse);

            // Assert
            detailsResult.ImdbId.Should().BeEquivalentTo(searchResult.ImdbId);
            detailsResult.Title.Should().BeEquivalentTo(searchResult.Title);
            detailsResult.Year.Should().BeEquivalentTo(searchResult.Year);
        }
    }
}
