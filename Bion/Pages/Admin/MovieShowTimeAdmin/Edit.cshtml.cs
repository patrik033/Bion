#nullable disable
using Bion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bion.Pages.Admin.MovieShowTimeAdmin
{
    public class EditModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public EditModel(Bion.Data.CinemaContext context)
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
           ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "CinemaName");
           ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MovieShowTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieShowTimeExists(MovieShowTime.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MovieShowTimeExists(int id)
        {
            return _context.MovieShowTimes.Any(e => e.Id == id);
        }
    }
}
