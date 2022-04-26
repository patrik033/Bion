#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Bion.Data;
using Bion.Models;

namespace Bion.Pages
{
    public class SalongOneModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public SalongOneModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public IList<MovieShowTime> MovieShowTime { get;set; }

        public async Task OnGetAsync()
        {
            MovieShowTime = await _context.MovieShowTimes
               .Include(m => m.Cinema)
               .Include(m => m.Movie).Where(x => x.CinemaId == 1).ToListAsync();
        }
    }
}
