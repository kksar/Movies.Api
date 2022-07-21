using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Entities
{
    public class Language
    {
        public Language()
        {
            LanguageMovies = new List<Movie>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [NotMapped]
        public decimal TotalMovies { get; set; }
        public List<Movie> LanguageMovies { get; set; }

    }
}
