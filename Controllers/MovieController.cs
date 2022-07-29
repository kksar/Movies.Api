using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Services;
using System.Text.Json;

namespace Movies.Api.Controllers
{
    [Route("api")]
    [ApiController]
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<MovieWithDetailsDto>>> GetMoviesAsync([FromQuery] string? name, [FromQuery] string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxMoviesPageSize)
            {
                pageSize = maxMoviesPageSize;
            }
            var (movies, paginationMetadata) = await _movieRepository.GetMoviesAsync(name, searchQuery, pageNumber, pageSize);

            Response.Headers.Add(
                "X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            //return Ok(movies);

            return Ok(_mapper.Map<IEnumerable<MovieWithDetailsDto>>(movies));
        }

        [HttpGet("moviesSinDetails")]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMoviesSinDetailsAsync()
        {

            var movies = await _movieRepository.GetMoviesAsync();
            return Ok(_mapper.Map<IEnumerable<MovieDto>>(movies));
            //return Ok(movies);
        }

        [HttpGet("movies/{movieId}")]
        public async Task<ActionResult<MovieDto>> GetMovieAsync(int movieId)
        {
            var movie = await _movieRepository.GetMovieAsync(movieId);

            if (movie is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<MovieWithDetailsDto>(movie));
        }

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
