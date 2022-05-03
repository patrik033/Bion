using Bion.Data;
using Bion.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;

namespace Bion.Pages.Bookings
{
    public class SummaryModel : PageModel
    {

        private readonly CinemaContext _context;
        [BindProperty]
        public TicketOrder TicketOrder { get; set; }
        private readonly IEmailSender _emailSender;
        public SummaryModel(CinemaContext context, IEmailSender emailSender)
        {
            _context = context;
            _emailSender = emailSender;
        }

        public void OnGet(int id)
        {
            TicketOrder = _context.TicketOrders.FirstOrDefault(o => o.Id == id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var builder = new BodyBuilder();

            await _emailSender.SendEmailAsync(TicketOrder.Email,"Order Confirmation",
                builder.HtmlBody = string.Format(
                    $"<p>Here's your order confirmation:<br>" +
                    $"Title: {TicketOrder.MovieTitle}<br>" +
                    $"Booked Seats: {TicketOrder.Seats}<br>" +
                    $"Price: {TicketOrder.Price}<br>" +
                    $"Booking Number: {TicketOrder.BookingNumber}<br>" +
                    $"Cinema {TicketOrder.SalongName}<br>" +
                    $"Starting time: {TicketOrder.Time}<br><br><br>" +
                    $"</p>" +
                    $"<h3><strong>Welcome back again!</strong></h3>"));
            return RedirectToPage("/Index");
        }
    }
}
