using Bion.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bion.Data
{
    public class CinemaContext : IdentityDbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<MovieShowTime> MovieShowTimes { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cinema>().HasData(
                new List<Cinema>()
                {
                    new Cinema{ Id = 1, CinemaName = "Poor man cinema"},
                    new Cinema{ Id = 2, CinemaName = "Fancy Cinema"}
                });

            modelBuilder.Entity<Movie>().HasData(
                new List<Movie>()
                {
                    new Movie{ Id = 1, Title = "Die Hard", RunTimeInHours = 2 },
                    new Movie{ Id = 2, Title = "Lord Of The Rings II", RunTimeInHours = 3 },
                });

            modelBuilder.Entity<MovieShowTime>().HasData(
                new List<MovieShowTime>()
                {
                    new MovieShowTime{ Id = 1, MovieScreeningTime = 13,
                        AvailableSeats = 50, MaxNumberSeats = 50,
                        CinemaId = 1,MovieId = 1},

                    new MovieShowTime{ Id = 2, MovieScreeningTime = 15,
                        AvailableSeats = 50, MaxNumberSeats = 50,
                        CinemaId = 1,MovieId = 2},

                    new MovieShowTime{ Id = 3, MovieScreeningTime = 18,
                        AvailableSeats = 50, MaxNumberSeats = 50,
                        CinemaId = 1,MovieId = 1},

                    new MovieShowTime{ Id = 4, MovieScreeningTime = 18,
                        AvailableSeats = 100, MaxNumberSeats = 100,
                        CinemaId = 2,MovieId = 1},

                    new MovieShowTime{ Id = 5, MovieScreeningTime = 20,
                        AvailableSeats = 100, MaxNumberSeats = 100,
                        CinemaId = 2,MovieId = 2},

                    new MovieShowTime{ Id = 6, MovieScreeningTime = 23,
                        AvailableSeats = 100, MaxNumberSeats = 100,
                        CinemaId = 2,MovieId = 1},
                });
            //RÖR EJ/DO NOT TOUCH!!! - Identity
            base.OnModelCreating(modelBuilder);
        }
    }
}
