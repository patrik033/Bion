using System.ComponentModel.DataAnnotations;

namespace Bion.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        [Required]
        public string? CinemaName { get; set; }
        public List<MovieShowTime>? ShowTimes { get; set; }
    }
}
