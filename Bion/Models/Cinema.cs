namespace Bion.Models
{
    public class Cinema
    {
        public int Id { get; set; }
        public string? CinemaName { get; set; }
        public List<MovieShowTime>? ShowTimes { get; set; }
    }
}
