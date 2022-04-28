using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            emailToSender.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = htmlMessage };
        
            //sending the email
            using(var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                emailClient.Authenticate("email", "password");
                emailClient.Send(emailToSender);
                emailClient.Disconnect(true);
            }
            return Task.CompletedTask;
        }

    }
}
