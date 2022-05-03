using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;

namespace BionModels.Models
{
    public class EmailSender : IEmailSender
    {
        //TODO: make an actual emailsender
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //configuration
            var emailToSender = new MimeMessage();
            emailToSender.From.Add(MailboxAddress.Parse("hello@bangansbio.com"));
            emailToSender.To.Add(MailboxAddress.Parse(email));
            emailToSender.Subject = subject;
            emailToSender.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
        
            //sending the email
            using(var emailClient = new SmtpClient())
            {
                //denna gör att du kan skicka mail - ta inte bort
                emailClient.CheckCertificateRevocation = false;
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("bangans.bio@gmail.com", "yxetizawatohpsxh");
                emailClient.Send(emailToSender);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }

    }
}
