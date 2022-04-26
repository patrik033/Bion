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
    public class IndexModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public IndexModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public IList<Cinema> Cinema { get;set; }

        public async Task OnGetAsync()
        {
            Cinema = await _context.Cinemas.ToListAsync();
        }
    }
}
