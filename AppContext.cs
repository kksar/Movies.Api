using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api
{
    public class AppContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-R7JAAC5\MSSQLSRV;Database=dbmovies;User Id=sa;Password=123;");
            base.OnConfiguring(optionsBuilder);
        }
    }
}