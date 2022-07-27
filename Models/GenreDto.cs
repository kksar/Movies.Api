namespace Movies.Api.Models
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int NumberOfMovies
        {
            get { return Movies.Count; }
        }

        public ICollection<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}
