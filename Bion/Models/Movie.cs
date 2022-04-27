using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bion.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        [Range(1,24)]
        [DisplayName("Run Time In Hours")]
        public int RunTimeInHours  { get; set; }
        public List<MovieShowTime>? ShowTimes { get; set; }
    }
}
