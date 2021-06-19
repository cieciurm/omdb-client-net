using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using OmdbClientNet.Details;
using OmdbClientNet.Search;

namespace OmdbClientNet
{
    public static class HttpMessageInvokerExtensions
    {
        public static Task<SearchMovieResponse> SearchMovies(this HttpMessageInvoker client, SearchMovieRequest request, CancellationToken cancellationToken = default)
        {
            var url = new OmdbApiUrlBuilder(request.ApiKey)
                .WithSearchRequest(request)
                .Build();

            return Get<SearchMovieResponse>(client, url, cancellationToken);
        }

        public static Task<MovieDetailsResponse> GetMovieDetails(this HttpMessageInvoker client, MovieDetailsRequest request, CancellationToken cancellationToken = default)
        {
            var url = new OmdbApiUrlBuilder(request.ApiKey)
                .WithDetailsRequest(request)
                .Build();

            return Get<MovieDetailsResponse>(client, url, cancellationToken);
        }

        private static async Task<T> Get<T>(HttpMessageInvoker client, string url, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var httpResponse = await client.SendAsync(httpRequest, cancellationToken);
            return await Deserialize<T>(httpResponse);
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage response)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<T>(stringResponse);
        }
    }
}
