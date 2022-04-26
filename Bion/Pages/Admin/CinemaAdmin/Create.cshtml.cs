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

namespace Bion.Pages.Admin.CinemaAdmin
{
    public class CreateModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public CreateModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Cinema Cinema { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Cinemas.Add(Cinema);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
