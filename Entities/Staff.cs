namespace Movies.Api.Entities
{
    public class Staff
    {
        public Staff()
        {
            Movies = new HashSet<Movie>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;

        // TODO: should be RoleId from table Role
        public string Role { get; set; } = string.Empty;

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
