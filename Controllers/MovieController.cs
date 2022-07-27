using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Services;
using System.Text.Json;

namespace Movies.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class MovieController : ControllerBase
    {

        const int maxMoviesPageSize = 20;
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieRepository, IMapper mapper)
        {
            _movieRepository = movieRepository ?? throw new ArgumentNullException(nameof(movieRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("movies")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesAsync([FromQuery] string? name, [FromQuery] string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxMoviesPageSize)
            {
                pageSize = maxMoviesPageSize;
            }
            var (movies, paginationMetadata) = await _movieRepository.GetMoviesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add(
                "X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(movies);

            //return Ok(_mapper.Map<IEnumerable<MovieWithDetailsDto>>(movies));
        }

        //[HttpGet("movieswithdetails")]
        //public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesWithMetaDataAsync()
        //{
        //    using var db = new AppContext();
        //    var movies = await db.Movies
        //        .Include(m => m.Genre)
        //        .Include(m => m.Language)
        //        .ToListAsync();

        //    return Ok(movies);
        //}

        //[HttpGet("{GenreId}/genremovies")]
        //public async Task<ActionResult<Genre>> GetMoviesOfGenreWithMetaDataAsync(int GenreId)
        //{
        //    using var db = new AppContext();

        //    var genre = await db.Genres
        //        .Include(g => g.GenreMovies)
        //        .ThenInclude(m => m.Language)
        //        .FirstAsync(g => g.Id == GenreId);

        //    foreach (Movie item in genre.GenreMovies)
        //    {
        //        item.Staffs = db.Movies.Where(m => m.Id == item.Id).SelectMany(m => m.Staffs).ToList();
        //    }
        //    return Ok(genre);
        //}

        //[HttpGet("{StaffId}/staffmovies")]
        //public async Task<ActionResult<Staff>> GetMoviesOfStaffWithMetaDataAsync(int StaffId)
        //{
        //    using var db = new AppContext();

        //    var staff = await db.Staffs
        //        .Include(s => s.Movies)
        //        .ThenInclude(m => m.Language)
        //        .FirstAsync(s => s.Id == StaffId);


        //    return Ok(staff);
        //}
    }
}
