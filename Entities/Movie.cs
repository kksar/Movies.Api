using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        //[ForeignKey("LanguageId")]
        public int LanguageId { get; set; }
        //[ForeignKey("OriginalLanguageId")]
        public int OriginalLanguageId { get; set; }

        [ForeignKey("GenreId")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; } = null!;


        public Movie()
        {
            Staffs = new HashSet<Staff>();
        }
        public virtual ICollection<Staff> Staffs { get; set; }

        public virtual Language Language { get; set; }
        public virtual Language OriginalLanguage { get; set; }

    }
}
