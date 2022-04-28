#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Bion.Data;
using Bion.Models;
using BionModels.IdentityTypes;
using Microsoft.AspNetCore.Authorization;

namespace Bion.Pages.Admin.MovieShowTimeAdmin
{
    [Authorize(Roles = $"{StaticDetails.ManagerRole}")]
    public class CreateModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public CreateModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CinemaId"] = new SelectList(_context.Cinemas, "Id", "CinemaName");
        ViewData["MovieId"] = new SelectList(_context.Movies, "Id", "Title");
            return Page();
        }

        [BindProperty]
        public MovieShowTime MovieShowTime { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MovieShowTimes.Add(MovieShowTime);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
