using Movies.Api.Entities;

namespace Movies.Api.Services
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<(IEnumerable<Movie>, PaginationMetadata)> GetMoviesAsync(string? name, string? searchQuery, int pageNumber, int pageSize);
        Task<Movie?> GetMovieAsync(int movieId);
        Task<IEnumerable<Staff>> GetStaffsForMovieAsync(int movieId);
        Task<Staff?> GetStaffForMovieAsync(int movieId, int staffId);
        Task<bool> MovieExistsAsync(int movieId);


        //Task AddPointOfInterestForCityAsync(int cityId, PointOfInterest pointOfInterest);
        //Task<bool> CityNameMatchesCityhId(string? cityName, int cityId);
        Task<bool> SaveChangeAsync();
        void DeleteMovie(Movie movie);

    }
}
