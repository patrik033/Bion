using System.ComponentModel.DataAnnotations.Schema;

namespace Bion.Models
{
    public class MovieShowTime
    {
        public int Id { get; set; }
        //Lista som ska hålla tiderna när en film visas
        [Column("Run Time")]
        public double MovieScreeningTime { get; set; }
        //Int som håller koll på lediga platser för vald film 
        public int AvailableSeats { get; set; }
        //Max antal platser som salongen kan hålla
        public int MaxNumberSeats { get; set; }
        public Cinema? Cinema { get; set; }
        public int CinemaId { get; set; }
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
    }
}
