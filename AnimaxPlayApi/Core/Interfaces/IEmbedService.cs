using AnimaxPlayApi.Core.Model;

namespace AnimaxPlayApi.Core.Interfaces
{
    public interface IEmbedService
    {
        Task<EmbedAvailability> CheckAvailabilityAsync(string tmdbId);
    }
}
