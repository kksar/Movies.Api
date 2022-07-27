using Movies.Api.Entities;

namespace Movies.Api.Models
{
    public class MovieWithDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public Language Language { get; set; } = null!;
        public Genre Genre { get; set; } = null!;
        public Staff Staff { get; set; } = null!;
    }
}
