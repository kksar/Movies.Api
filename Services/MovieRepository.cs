using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;


namespace Movies.Api.Services
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieContext _appContext;

        public MovieRepository(MovieContext appContext)
        {
            _appContext = appContext;
        }
        public async Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            return await _appContext.Movies.OrderBy(m => m.Title).ToListAsync();
        }

        public async Task<Movie?> GetMovieAsync(int movieId)
        {
            return await _appContext.Movies.Where(m => m.Id == movieId)
                .Include(m => m.Genre)
                .Include(m => m.Language)
                .Include(m => m.OriginalLanguage)
                .Include(m => m.Staffs)
                .FirstOrDefaultAsync();
        }

        public async Task<(IEnumerable<Movie>, PaginationMetadata)> GetMoviesAsync(string? title, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _appContext.Movies as IQueryable<Movie>;
            collection = collection
                .Include(m => m.Language)
                .Include(m => m.OriginalLanguage)
                .Include(m => m.Genre)
                .Include(m => m.Staffs);

            if (!string.IsNullOrEmpty(title))
            {
                title = title.Trim();
                collection = collection.Where(c => c.Title == title);
            }
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                searchQuery = searchQuery.Trim();
                collection = collection.Where(a => a.Title.Contains(searchQuery) || (a.Description != null && a.Description.Contains(searchQuery)));
            }

            var totalItemCount = await collection.CountAsync();

            var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);


            var collectionToReturn = await collection.OrderBy(c => c.Title).Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            return (collectionToReturn, paginationMetadata);
        }

        public Task<bool> MovieExistsAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
