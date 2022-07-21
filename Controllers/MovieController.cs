using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Controllers
{
    [Route("api/movies")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        const int maxMoviesPageSize = 20;
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            using var db = new AppContext();
            var movies = await db.Movies.ToListAsync();

            return Ok(movies);
        }
    }
}
