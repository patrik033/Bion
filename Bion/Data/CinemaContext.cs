using Bion.Models;
using Microsoft.EntityFrameworkCore;

namespace Bion.Data
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) { }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieShowTime> MovieShowTimes { get; set; }
    }
}
