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
using BionModels.IdentityTypes;
using Microsoft.AspNetCore.Authorization;

namespace Bion.Pages.Admin.MovieShowTimeAdmin
{
    [Authorize(Roles = $"{StaticDetails.ManagerRole}")]
    public class DeleteModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public DeleteModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MovieShowTime MovieShowTime { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieShowTime = await _context.MovieShowTimes
                .Include(m => m.Cinema)
                .Include(m => m.Movie).FirstOrDefaultAsync(m => m.Id == id);

            if (MovieShowTime == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MovieShowTime = await _context.MovieShowTimes.FindAsync(id);

            if (MovieShowTime != null)
            {
                _context.MovieShowTimes.Remove(MovieShowTime);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
