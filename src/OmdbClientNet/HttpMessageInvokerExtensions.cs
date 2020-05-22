using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using OmdbClientNet.Details;
using OmdbClientNet.Search;

namespace OmdbClientNet
{
    public static class HttpMessageInvokerExtensions
    {
        public static Task<SearchMovieResponse> SearchMovies(this HttpMessageInvoker client, SearchMovieRequest request, Func<string, SearchMovieResponse> deserializeFunc, CancellationToken cancellationToken = default)
        {
            var url = new OmdbApiUrlBuilder(request.ApiKey)
                .WithSearchRequest(request)
                .Build();

            return Get(client, url, deserializeFunc, cancellationToken);
        }

        public static Task<MovieDetailsResponse> GetMovieDetails(this HttpMessageInvoker client, MovieDetailsRequest request, Func<string, MovieDetailsResponse> deserializeFunc, CancellationToken cancellationToken = default)
        {
            var url = new OmdbApiUrlBuilder(request.ApiKey)
                .WithDetailsRequest(request)
                .Build();

            return Get(client, url, deserializeFunc, cancellationToken);
        }

        private static async Task<T> Get<T>(HttpMessageInvoker client, string url, Func<string, T> deserializeFunc, CancellationToken cancellationToken = default)
        {
            var httpRequest = new HttpRequestMessage(HttpMethod.Get, url);
            var httpResponse = await client.SendAsync(httpRequest, cancellationToken);
            return await Deserialize(httpResponse, deserializeFunc);
        }

        private static async Task<T> Deserialize<T>(HttpResponseMessage response, Func<string, T> deserializeFunc)
        {
            var stringResponse = await response.Content.ReadAsStringAsync();
            return deserializeFunc(stringResponse);
        }
    }
}
