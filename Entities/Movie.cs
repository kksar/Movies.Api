using System.ComponentModel.DataAnnotations;

namespace Movies.Api.Entities
{
    public class Movie
    {
        public Movie()
        {
            Staffs = new HashSet<Staff>();
        }

        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int ReleaseYear { get; set; }
        public int LanguageId { get; set; }
        public int OriginalLanguageId { get; set; }
        public Language Language { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }




        public virtual ICollection<Staff> Staffs { get; set; }


        //public int NumberOfPointsOfInterest
        //{
        //    get
        //    {
        //        return PointsOfInterest.Count;
        //    }
        //}

        //public ICollection<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();
    }
}
