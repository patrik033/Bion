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

namespace Bion.Pages.Admin.CinemaAdmin
{
    public class DetailsModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public DetailsModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public Cinema Cinema { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cinema = await _context.Cinemas.FirstOrDefaultAsync(m => m.Id == id);

            if (Cinema == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
