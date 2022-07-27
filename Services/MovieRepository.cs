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

        public void DeleteMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie?> GetMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }



        public async Task<(IEnumerable<Movie>, PaginationMetadata)> GetMoviesAsync(string? title, string? searchQuery, int pageNumber, int pageSize)
        {
            var collection = _appContext.Movies as IQueryable<Movie>;
            collection = collection.Include(c => c.Language).Include(c => c.Genre).Include(c => c.Staffs);
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

        public Task<Staff?> GetStaffForMovieAsync(int movieId, int staffId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Staff>> GetStaffsForMovieAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> MovieExistsAsync(int movieId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChangeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
