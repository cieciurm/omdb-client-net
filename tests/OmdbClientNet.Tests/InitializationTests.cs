using System;
using System.Net.Http;
using OmdbClientNet.Details;
using OmdbClientNet.Exceptions;
using OmdbClientNet.Search;
using Shouldly;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class InitializationTests
    {
        private readonly HttpClient _httpClient;

        public InitializationTests()
        {
            _httpClient = new HttpClient();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void GetMovieDetails_WhenApiKeyMissing_ThenThrowsException(string apiKey)
        {
            // Arrange
            var request = new MovieDetailsRequest(apiKey, new ImdbId(Guid.NewGuid().ToString()));

            // Act
            Action action = () => _httpClient.GetMovieDetails(request);

            // Assert
            action.ShouldThrow<MissingOmdbApiKeyException>();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void SearchMovies_WhenApiKeyMissing_ThenThrowsException(string apiKey)
        {
            // Arrange
            var request = new SearchMovieRequest(apiKey, "abc");

            // Act
            Action action = () => _httpClient.SearchMovies(request);

            // Assert
            action.ShouldThrow<MissingOmdbApiKeyException>();
        }
    }
}
