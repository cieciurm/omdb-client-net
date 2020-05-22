using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace OmdbClientNet.Tests.Common
{
    public class OmdbClassFixture
    {
        public OmdbSettings OmdbSettings { get; } = new OmdbSettings();

        public HttpMessageInvoker Client { get; } = new HttpClient();

        public T DeserializeObject<T>(string content) => JsonConvert.DeserializeObject<T>(content);

        public OmdbClassFixture()
        {
            var configuration = BuildConfiguration();
            configuration.Bind(OmdbSettings);
        }

        private static IConfiguration BuildConfiguration() =>
            new ConfigurationBuilder()
                .AddJsonFile("settings.json", optional: true)
                .Build();
    }
}