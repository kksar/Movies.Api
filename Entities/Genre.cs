using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Entities
{
    public class Genre
    {
        public Genre()
        {
            GenreMovies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public decimal TotalMovies { get; set; }
        public List<Movie> GenreMovies { get; set; } //****

    }
}
