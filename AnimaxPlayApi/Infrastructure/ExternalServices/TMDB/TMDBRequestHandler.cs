using System.Net.Http.Headers;

namespace AnimaxPlayApi.Infrastructure.ExternalServices.TMDB
{
    public class TMDBRequestHandler
    {

        private readonly HttpClient _httpClient;
        private readonly TMDBOptions _options;
        private readonly string _baseUrl;

        public TMDBRequestHandler(HttpClient httpClient, TMDBOptions options)
        {
            _httpClient = httpClient;
            _options = options;
            _baseUrl = options.BaseUrl.TrimEnd('/');
        }

        public async Task<T?> GetAsync<T>(string relativeUrl)
        {
            var url = $"{_baseUrl}/{relativeUrl.TrimStart('/')}";

            var request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return System.Text.Json.JsonSerializer.Deserialize<T>(json, new System.Text.Json.JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
    }
}
