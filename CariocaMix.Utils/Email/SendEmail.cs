using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;

namespace CariocaMix.Utils.Email
{
    public class SendEmail
    {
        private static IConfiguration _config;

        public SendEmail(IConfiguration config)
        {
            _config = config;
        }

        public static void SendOneEmail(string subject, string body, string recipient)
        {
            var username = _config.GetSection("Email:Username")?.Value;
            var password = _config.GetSection("Email:password")?.Value;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = false,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(username),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(recipient);

            smtpClient.Send(mailMessage);
        }

        public static void SendListEmail(string subject, string body, List<string> recipients)
        {
            var username = _config.GetSection("Email:Username")?.Value;
            var password = _config.GetSection("Email:password")?.Value;
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(username, password),
                EnableSsl = false,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(username),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            string delimiter = ",";
            mailMessage.To.Add(recipients.Aggregate((i, j) => i + delimiter + j));

            smtpClient.Send(mailMessage);
        }
    }
}
