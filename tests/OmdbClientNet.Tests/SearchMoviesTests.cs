using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OmdbClientNet.Base;
using OmdbClientNet.Search;
using OmdbClientNet.Tests.Common;
using Shouldly;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class SearchMoviesTests : IClassFixture<OmdbClassFixture>
    {
        private readonly OmdbSettings _omdbSettings;
        private readonly HttpMessageInvoker _client;

        public SearchMoviesTests(OmdbClassFixture omdbClassFixture)
        {
            _omdbSettings = omdbClassFixture.OmdbSettings;
            _client = omdbClassFixture.Client;
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
            var searchResponse = await _client.SearchMovies(request);

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
            var searchResponse = await _client.SearchMovies(request);

            // Assert
            searchResponse.ShouldBeSuccessful();

            searchResponse.TotalResultsInt.ShouldBe(3);
            searchResponse.Search.Select(x => x.Year).Distinct().ShouldContain(x => x.Equals(year.ToString()));
        }
    }
}
