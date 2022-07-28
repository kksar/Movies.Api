using Movies.Api.Entities;

namespace Movies.Api.Services
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<(IEnumerable<Movie>, PaginationMetadata)> GetMoviesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Movie?> GetMovieAsync(int movieId);

        Task<bool> MovieExistsAsync(int movieId);

        //Task AddMovieAsync(int cityId, PointOfInterest pointOfInterest);

        Task<bool> SaveChangeAsync();
        void DeleteMovie(Movie movie);

    }
}
