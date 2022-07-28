using Movies.Api.Entities;

namespace Movies.Api.Services
{
    public interface ILanguageRepository
    {
        Task<IEnumerable<Movie>> GetMoviesForLanguageAsync(int languageId);
        Task<(IEnumerable<Language>, PaginationMetadata)> GetLanguagesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Language?> GetLanguageAsync(int languageId);
        Task<bool> LanguageExistsAsync(int languageId);

        //Task AddLanguageAsync(int cityId, PointOfInterest pointOfInterest);

        Task<bool> SaveChangeAsync();
    }
}
