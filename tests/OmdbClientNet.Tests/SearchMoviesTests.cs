using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using OmdbClientNet.Base;
using OmdbClientNet.Search;
using OmdbClientNet.Tests.Common;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class SearchMoviesTests : IClassFixture<OmdbClassFixture>
    {
        private readonly OmdbSettings _omdbSettings;
        private readonly HttpMessageInvoker _client;
        private readonly Func<string, SearchMovieResponse> _deserializeResponse;

        public SearchMoviesTests(OmdbClassFixture omdbClassFixture)
        {
            _omdbSettings = omdbClassFixture.OmdbSettings;
            _client = omdbClassFixture.Client;
            _deserializeResponse = omdbClassFixture.DeserializeObject<SearchMovieResponse>;
        }

        [Fact]
        public async Task SearchMovies_WhenCorrectDataPassed_ReturnsResults()
        {
            // Arrange
            var request = new SearchMovieRequest(_omdbSettings.ApiKey, "Batman")
            {
                Type = ResultType.Movie
            };

            // Act
            var searchResponse = await _client.SearchMovies(request, _deserializeResponse);

            // Assert
            searchResponse.ShouldBeSuccessful();
        }

        [Fact]
        public async Task SearchMovies_WhenYearPassed_ReturnsMovieFromThisYear()
        {
            // Arrange
            const int year = 1995;
            var request = new SearchMovieRequest(_omdbSettings.ApiKey, "Batman")
            {
                Type = ResultType.Movie,
                Year = year,
            };

            // Act
            var searchResponse = await _client.SearchMovies(request, _deserializeResponse);

            // Assert
            searchResponse.ShouldBeSuccessful();

            searchResponse.Response.Should().BeTrue(); 
            searchResponse.TotalResults.Should().Be(3);
            searchResponse.Search.Select(x => x.Year).Should().OnlyContain(x => x.Equals(year.ToString()));
        }
    }
}
