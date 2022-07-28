using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api.Services
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly MovieContext _appContext;

        public LanguageRepository(MovieContext movieContext)
        {
            _appContext = movieContext;
        }

        public async Task<Language?> GetLanguageAsync(int languageId)
        {
            return await _appContext.Languages.Where(l => l.Id == languageId).FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<Language>, PaginationMetadata)> GetLanguagesAsync(string? name, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _appContext.Languages as IQueryable<Language>;
            collection = collection
                .Include(l => l.Movies)
                .ThenInclude(m => m.OriginalLanguage)
                .Include(l => l.Movies)
                .ThenInclude(m => m.Staffs)
                .Include(l => l.Movies)
                .ThenInclude(m => m.Genre);

            if (!string.IsNullOrEmpty(name))
            {
                name = name.Trim();
                collection = collection.Where(c => c.Name == name);
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Name.Contains(searchQuery));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);


            var collectionToReturn = await collection.OrderBy(c => c.Name).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public async Task<IEnumerable<Movie>> GetMoviesForLanguageAsync(int languageId)
        {
            return await _appContext.Movies.Where(m => m.LanguageId == languageId)
                .Include(m => m.Language)
                .Include(m => m.OriginalLanguage)
                .Include(m => m.Genre)
                .Include(m => m.Staffs)
                .ToListAsync();
        }

        public async Task<bool> LanguageExistsAsync(int languageId)
        {
            return await _appContext.Languages.AnyAsync(l => l.Id == languageId);
        }

        public Task<bool> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
