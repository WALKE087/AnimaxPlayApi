using AnimaxPlayApi.WebAPI.Middleware;
using Microsoft.AspNetCore.Mvc;

namespace AnimaxPlayApi.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FirebaseController : ControllerBase
    {
        [HttpGet]
        [FirebaseAuthorize]
        public IActionResult GetMovies()
        {
            var userId = HttpContext.Items["UserId"]?.ToString();
            return Ok($"Usuario autenticado: {userId}");
        }
    }
}
