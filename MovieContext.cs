using Microsoft.EntityFrameworkCore;
using Movies.Api.Entities;

namespace Movies.Api
{
    public class MovieContext : DbContext
    {

        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Staff> Staffs { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<Language> Languages { get; set; } = null!;
        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>()
                    .HasOne(m => m.Language)
                    .WithMany(t => t.Movies)
                    .HasForeignKey(m => m.LanguageId)
                    .OnDelete(DeleteBehavior.NoAction).IsRequired();

            modelBuilder.Entity<Movie>()
                        .HasOne(m => m.OriginalLanguage)
                        .WithMany(t => t.MoviesOrign)
                        .HasForeignKey(m => m.OriginalLanguageId)
                        .OnDelete(DeleteBehavior.NoAction).IsRequired();
        }
    }



    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-R7JAAC5\MSSQLSRV;Database=dbmovies;User Id=sa;Password=123;");
    //    base.OnConfiguring(optionsBuilder);
    //}
}