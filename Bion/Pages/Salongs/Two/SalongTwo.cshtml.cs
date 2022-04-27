#nullable disable
using Bion.Data;
using Bion.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Bion.Pages
{
    public class SalongTwoModel : PageModel
    {
        private readonly CinemaContext _context;

        public SalongTwoModel(CinemaContext context)
        {
            _context = context;
        }

        public IList<MovieShowTime> MovieShowTime { get;set; }

        public async Task OnGetAsync()
        {
            MovieShowTime = await _context.MovieShowTimes
               .Include(m => m.Cinema)
               .Include(m => m.Movie).Where(x => x.CinemaId == 2).ToListAsync();
        }
    }
}
