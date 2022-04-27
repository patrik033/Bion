using Bion.Data;
using Bion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Bion.Pages.Bookings
{
    public class SummaryModel : PageModel
    {

        private readonly CinemaContext _context;
        [BindProperty]
        public TicketOrder TicketOrder { get; set; }
        public SummaryModel(CinemaContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            TicketOrder = _context.TicketOrders.FirstOrDefault(o => o.Id == id);
        }
    }
}
