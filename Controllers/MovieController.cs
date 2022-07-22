using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        const int maxMoviesPageSize = 20;
        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
        {
            using var db = new AppContext();
            var movies = await db.Movies.ToListAsync();

            return Ok(movies);
        }

        [HttpGet("movieswithdetails")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesWithMetaDataAsync()
        {
            using var db = new AppContext();
            var movies = await db.Movies
                .Include(m => m.Genre)
                .Include(m => m.Language)
                .ToListAsync();

            return Ok(movies);
        }

        [HttpGet("{GenreId}/genremovies")]
        public async Task<ActionResult<Genre>> GetMoviesOfGenreWithMetaDataAsync(int GenreId)
        {
            using var db = new AppContext();

            var genre = await db.Genres
                .Include(g => g.GenreMovies)
                .ThenInclude(m => m.Language)
                .FirstAsync(g => g.Id == GenreId);

            foreach (Movie item in genre.GenreMovies)
            {
                item.Staffs = db.Movies.Where(m => m.Id == item.Id).SelectMany(m => m.Staffs).ToList();
            }
            return Ok(genre);
        }

        [HttpGet("{StaffId}/staffmovies")]
        public async Task<ActionResult<Staff>> GetMoviesOfStaffWithMetaDataAsync(int StaffId)
        {
            using var db = new AppContext();

            var staff = await db.Staffs
                .Include(s => s.Movies)
                .ThenInclude(m => m.Language)
                .FirstAsync(s => s.Id == StaffId);


            return Ok(staff);
        }
    }
}
