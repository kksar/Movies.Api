namespace Movies.Api.Models
{
    public class LanguageDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public int NumberOfMovies
        {
            get { return Movies.Count; }
        }

        public ICollection<MovieDto> Movies { get; set; } = new List<MovieDto>();
    }
}
