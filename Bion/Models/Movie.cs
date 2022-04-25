namespace Bion.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int RunTimeInHours  { get; set; }
        public List<MovieShowTime>? ShowTimes { get; set; }
    }
}
