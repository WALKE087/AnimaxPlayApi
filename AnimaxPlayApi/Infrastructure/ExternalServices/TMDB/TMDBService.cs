using AnimaxPlayApi.Core.Model;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AnimaxPlayApi.Infrastructure.ExternalServices.TMDB
{
    public class TMDBService
    {
        private readonly TMDBRequestHandler _requestHandler;

        public TMDBService(HttpClient httpClient, IOptions<TMDBOptions> options)
        {
            var opts = options.Value;
            _requestHandler = new TMDBRequestHandler(httpClient, opts);
        }

        public Task<MovieResponse?> GetPopularMoviesAsync(int page = 1)
        {
            return _requestHandler.GetAsync<MovieResponse>($"movie/popular?language=es-ES&page={page}");
        }

        public Task<MovieResponse?> SearchMoviesAsync(string query)
        {
            var safeQuery = Uri.EscapeDataString(query);
            return _requestHandler.GetAsync<MovieResponse>($"search/multi?query={safeQuery}&language=es-ES&page=1");
        }
        
    }
}
