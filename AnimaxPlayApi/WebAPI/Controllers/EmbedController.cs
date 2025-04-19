using AnimaxPlayApi.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnimaxPlayApi.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmbedController : ControllerBase
    {
        private readonly IEmbedService _embedService;
        public EmbedController(IEmbedService embedService)
        {
            _embedService = embedService;
        }

        [HttpGet("embed/{tmdbId}")]
        public async Task<IActionResult> GetEmbedAvailability(string tmdbId)
        {
            var embedAvailability = await _embedService.CheckAvailabilityAsync(tmdbId);

            if (embedAvailability.IsAvailableOnEmbedSu || embedAvailability.IsAvailableOnVidsrc)
            {
                return Ok(embedAvailability);
            }

            return NotFound("La película no está disponible en Embed.su o Vidsrc.");
        }
    }
}
