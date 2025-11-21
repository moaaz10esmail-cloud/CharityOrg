using Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendEmailAsync(string to, string subject, string body, byte[] attachment, string fileName)
        {
            using var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                Credentials = new NetworkCredential("your-email@gmail.com", "your-app-password"),
                EnableSsl = true
            };

            var mail = new MailMessage("your-email@gmail.com", to, subject, body);

            if (attachment != null)
            {
                mail.Attachments.Add(new Attachment(new MemoryStream(attachment), fileName));
            }

            await smtp.SendMailAsync(mail);
        }
    }
}