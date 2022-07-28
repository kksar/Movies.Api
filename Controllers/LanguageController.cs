using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Movies.Api.Models;
using Movies.Api.Services;
using System.Text.Json;

namespace Movies.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        const int maxMoviesPageSize = 20;
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository ?? throw new ArgumentNullException(nameof(languageRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("languages")]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguagesAsync([FromQuery] string? name, [FromQuery] string? searchQuery, int pageNumber = 1, int pageSize = 10)
        {
            if (pageSize > maxMoviesPageSize)
            {
                pageSize = maxMoviesPageSize;
            }
            var (languages, paginationMetadata) = await _languageRepository.GetLanguagesAsync(name, searchQuery, pageNumber, pageSize);
            //var languages = await _languageRepository.GetLanguagesAsync();
            Response.Headers.Add(
                "X-Pagination",
                JsonSerializer.Serialize(paginationMetadata));

            return Ok(_mapper.Map<IEnumerable<LanguageDto>>(languages));
        }

        [HttpGet("languages/{languageId}")]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetLanguageAsync(int languageId)
        {
            var language = await _languageRepository.GetLanguageAsync(languageId);

            if (language is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<LanguageDto>(language));
        }

        [HttpGet("languages/{languageId}/movies")]
        public async Task<ActionResult<IEnumerable<LanguageDto>>> GetMoviesForLanguageAsync(int languageId)
        {
            var language = await _languageRepository.LanguageExistsAsync(languageId);

            if (!language)
            {
                return NotFound();
            }

            var movies = await _languageRepository.GetMoviesForLanguageAsync(languageId);

            return Ok(_mapper.Map<IEnumerable<MovieWithDetailsDto>>(movies));
        }
    }
}
