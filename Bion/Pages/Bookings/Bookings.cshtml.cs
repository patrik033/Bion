using Bion.Data;
using Bion.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bion.Pages.Bookings
{
    public class BookingsModel : PageModel
    {


        [BindProperty]
        public MovieShowTime MovieShowTime { get; set; }
        [BindProperty]
        public TicketOrder TicketOrder { get; set; }

        //TODO change name
        public decimal MyPrice { get; set; }



        private readonly CinemaContext _context;

        public BookingsModel(CinemaContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            TicketOrder = new TicketOrder();

            MovieShowTime = await _context.MovieShowTimes
                .Include(m => m.Cinema)
                .Include(m => m.Movie).FirstOrDefaultAsync(m => m.Id == id);

            if (MovieShowTime == null)
            {
                return NotFound();
            }
          
            
            TicketOrder.Price = SetPrice();
            
            return Page();
        }

        public IActionResult OnPost()
        {
            TicketOrder.MovieShowTime = MovieShowTime;
            TicketOrder.Price = TotalCost();
            return Page();
        }
        private decimal SetPrice()
        {
            var movie = MovieShowTime.MovieId;
            var time = MovieShowTime.MovieScreeningTime;
            decimal price = 0M;
            if (time >= 13 && time <= 18 && movie == 1)
                price = 120M;
            else if (time >= 13 && time <= 18 && movie == 2)
                price = 180M;
            return price;
        }

        private decimal TotalCost()
        {
            TicketOrder.Price = TicketOrder.Price * TicketOrder.Seats;
            return TicketOrder.Price;
        }
    }
}
