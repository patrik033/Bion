using System.ComponentModel.DataAnnotations;

namespace Bion.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int RunTimeInHours  { get; set; }
        public List<MovieShowTime>? ShowTimes { get; set; }
    }
}
