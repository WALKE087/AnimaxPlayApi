using AnimaxPlayApi.Core.Interfaces;
using AnimaxPlayApi.Infrastructure.ExternalServices.TMDB;
using Microsoft.AspNetCore.Mvc;

namespace AnimaxPlayApi.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly TMDBService _tmdbService;

        public MoviesController(TMDBService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [HttpGet("popular")]
        public async Task<IActionResult> GetPopular([FromQuery] int page = 1)
        {
            try
            {
                var result = await _tmdbService.GetPopularMoviesAsync(page);
                if (result == null || result.Results == null)
                    return NotFound("No se encontraron películas populares.");

                return Ok(new
                {
                    currentPage = page,
                    totalPages = result.Total_Pages,
                    totalResults = result.Total_Results,
                    items = result.Results
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al obtener películas: {ex.Message}");
            }
        }


        [HttpGet("search")]
        public async Task<IActionResult> SearchMovies([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("El parámetro 'query' es obligatorio.");

            var result = await _tmdbService.SearchMoviesAsync(query);

            if (result == null || result.Results == null || result.Results.Count == 0)
                return NotFound("No se encontraron películas con ese nombre.");

            return Ok(result);
        }
    }
}
