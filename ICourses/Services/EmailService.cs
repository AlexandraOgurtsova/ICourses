using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ICourses.Services
{
    public class EmailService
    {
        public async Task SendEmailAsync(string reciever, string subject, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "ogurtsova-01@mail.ru"));
            emailMessage.To.Add(new MailboxAddress("", reciever));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("ogurtsova-01@mail.ru", "20022001alog");
                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }
       
    }
}
