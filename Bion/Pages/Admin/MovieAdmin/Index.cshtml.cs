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

namespace Bion.Pages.Admin.MovieAdmin
{
    [Authorize(Roles = $"{StaticDetails.ManagerRole}")]
    public class IndexModel : PageModel
    {
        private readonly Bion.Data.CinemaContext _context;

        public IndexModel(Bion.Data.CinemaContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
