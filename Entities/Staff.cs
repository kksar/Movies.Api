using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movies.Api.Entities
{
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        // TODO: should be RoleId from table Role
        [Required]
        [MaxLength(50)]
        public string Role { get; set; } = string.Empty;
        public Staff()
        {
            Movies = new HashSet<Movie>();
        }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
