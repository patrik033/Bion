using System.ComponentModel.DataAnnotations.Schema;

namespace Bion.Models
{
    public class MovieShowTime
    {
        public int Id { get; set; }
        //Lista som ska hålla tiderna när en film visas
        public double MovieScreeningTime { get; set; }
        //Int som håller koll på lediga platser för vald film 
        public int AvailableSeats { get; set; }
        //Max antal platser som salongen kan hålla
        public int MaxNumberSeats { get; set; }
        //Biljettpris 
        [Column(TypeName = "decimal(18,2)")]
        public decimal TicketPrice { get; set; } = 100M;
        public Cinema? Cinema { get; set; }
        public int CinemaId { get; set; }
        public Movie? Movie { get; set; }
        public int MovieId { get; set; }
    }
}
