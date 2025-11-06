using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiDemo
{
    public class MovieContext: DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options): base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Director = "Christopher Nolan", ReleaseYear = 2010, Genre = "Sci-Fi" },
                new Movie { Id = 2, Title = "The Dark Knight", Director = "Christopher Nolan", ReleaseYear = 2008, Genre = "Action" },
                new Movie { Id = 3, Title = "Pulp Fiction", Director = "Quentin Tarantino", ReleaseYear = 1994, Genre = "Crime" },
                new Movie { Id = 4, Title = "The Shawshank Redemption", Director = "Frank Darabont", ReleaseYear = 1994, Genre = "Drama" },
                new Movie { Id = 5, Title = "The Godfather", Director = "Francis Ford Coppola", ReleaseYear = 1972, Genre = "Crime" }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
