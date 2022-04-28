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
                .Include(m => m.Movie).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id);

            if (MovieShowTime == null)
            {
                return NotFound();
            }
            TicketOrder.Price = SetPrice();
            return Page();
        }


        public IActionResult OnPost()
        {

            var cinema = _context.MovieShowTimes.FirstOrDefault(x => x.Id == MovieShowTime.Id);


            TicketOrder.Price = TotalCost();
            TicketOrder.BookingNumber = GenerateBookingNumber();

            MovieShowTime.AvailableSeats -= TicketOrder.Seats;
            if (MovieShowTime.AvailableSeats < 0)
            {
                ModelState.AddModelError(String.Empty, $"Sorry, there's no more than {MovieShowTime.AvailableSeats+TicketOrder.Seats} seats available");
                return Page();
            }
            else
            {

                var correct = MovieShowTime.AvailableSeats;
                cinema.AvailableSeats = correct;
                _context.SaveChanges();
                _context.ChangeTracker.Clear();

                var ticket = new TicketOrder
                {
                    FirstName = TicketOrder.FirstName,
                    LastName = TicketOrder.LastName,
                    Email = TicketOrder.Email,
                    Seats = TicketOrder.Seats,
                    Price = TicketOrder.Price,
                    MovieTitle = MovieShowTime.Movie.Title,
                    BookingNumber = TicketOrder.BookingNumber,
                    SalongName = MovieShowTime.Cinema.CinemaName,
                    Time = MovieShowTime.MovieScreeningTime.ToString() + ":00",
                };

                 _context.TicketOrders.Add(ticket);
                 _context.SaveChanges();
                return RedirectToPage("Summary", new { id = ticket.Id });
            }
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
            else
                price = 100M;
            return price;
        }

        private decimal TotalCost()
        {
            TicketOrder.Price = TicketOrder.Price * TicketOrder.Seats;
            return TicketOrder.Price;
        }

        private string GenerateBookingNumber()
        {
            long i = 1;
            foreach (byte b in Guid.NewGuid().ToByteArray())
            {
                i *= ((int)b + 1);
            }
            return string.Format("{0:x}", i - DateTime.Now.Ticks);
        }
    }
}
