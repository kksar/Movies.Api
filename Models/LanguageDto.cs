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
        //[JsonIgnore]
        public ICollection<MovieWithDetailsDto> Movies { get; set; } = new List<MovieWithDetailsDto>();
    }
}
