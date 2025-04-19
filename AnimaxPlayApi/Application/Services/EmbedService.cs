using AnimaxPlayApi.Core.Interfaces;
using AnimaxPlayApi.Core.Model;

namespace AnimaxPlayApi.Application.Services
{
    public class EmbedService : IEmbedService
    {
        private readonly HttpClient _httpClient;

        public EmbedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmbedAvailability> CheckAvailabilityAsync(string tmdbId)
        {
            var embedSuAvailable = await CheckEmbedSuAvailabilityAsync(tmdbId);
            var vidsrcAvailable = await CheckVidsrcAvailabilityAsync(tmdbId);

            return new EmbedAvailability
            {
                TmdbId = tmdbId,
                IsAvailableOnEmbedSu = embedSuAvailable,
                IsAvailableOnVidsrc = vidsrcAvailable
            };
        }

        private async Task<bool> CheckEmbedSuAvailabilityAsync(string tmdbId)
        {
            // Lógica para verificar disponibilidad en Embed.su
            var url = $"https://embed.su/embed/movie/{tmdbId}";
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode;
        }

        private async Task<bool> CheckVidsrcAvailabilityAsync(string tmdbId)
        {
            // Lógica para verificar disponibilidad en Vidsrc
            var url = $"https://vidsrc.xyz/embed/movie?tmdb={tmdbId}";
            var response = await _httpClient.GetAsync(url);
            return response.IsSuccessStatusCode;
        }
    }
}
