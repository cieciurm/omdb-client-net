using System;
using System.Net.Http;
using System.Threading.Tasks;
using OmdbClientNet.Base;
using OmdbClientNet.Details;
using OmdbClientNet.Tests.Common;
using Xunit;

namespace OmdbClientNet.Tests
{
    public class MovieDetailsTests : IClassFixture<OmdbClassFixture>
    {
        private readonly HttpMessageInvoker _client;
        private readonly OmdbSettings _omdbSettings;
        private readonly Func<string, MovieDetailsResponse> _deserializeResponse;

        public MovieDetailsTests(OmdbClassFixture omdbClassFixture)
        {
            _client = omdbClassFixture.Client;
            _omdbSettings = omdbClassFixture.OmdbSettings;
            _deserializeResponse = omdbClassFixture.DeserializeObject<MovieDetailsResponse>;
        }

        [Fact]
        public async Task GetMovieDetails_WhenCorrectImdbId_ShouldReturnMovie()
        {
            // Arrange
            var request = new MovieDetailsRequest(_omdbSettings.ApiKey, "tt0096895")
            {
                PlotType = PlotType.Full,
            };

            // Act
            var response = await _client.GetMovieDetails(request, _deserializeResponse);

            // Assert
            response.ShouldBeSuccessful();
        }
    }
}
