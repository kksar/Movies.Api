﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Movies.Api.Entities
{
    public class Language
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        //[JsonIgnore]
        //public ICollection<Movie> Movies { get; set; } = new List<Movie>();
        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
        [JsonIgnore]
        public virtual ICollection<Movie> MoviesOrign { get; set; } = new List<Movie>();

    }
}
