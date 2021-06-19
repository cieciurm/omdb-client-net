using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OmdbClientNet.Details;
using OmdbClientNet.Search;
using OmdbClientNet.Tests.Common;
using Shouldly;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class CombinedMovieTests : IClassFixture<OmdbClassFixture>
    {
        private readonly HttpMessageInvoker _client;
        private readonly OmdbSettings _omdbSettings;

        public CombinedMovieTests(OmdbClassFixture omdbClassFixture)
        {
            _client = omdbClassFixture.Client;
            _omdbSettings = omdbClassFixture.OmdbSettings;
        }

        [Fact]
        public async Task SearchMoviesAndGetMovieDetails_PropertiesShouldMatch()
        {
            // Arrange & Act
            var searchRequest = new SearchMovieRequest(_omdbSettings.ApiKey, "Batman");

            var searchResults = await _client.SearchMovies(searchRequest);
            var searchResult = searchResults.Search.ToList()[0];

            var detailsRequest = new MovieDetailsRequest(_omdbSettings.ApiKey, new ImdbId(searchResult.ImdbId));

            var detailsResult = await _client.GetMovieDetails(detailsRequest);

            // Assert
            detailsResult.ImdbId.ShouldBe(searchResult.ImdbId);
            detailsResult.Title.ShouldBe(searchResult.Title);
            detailsResult.Year.ShouldBe(searchResult.Year);
        }
    }
}
