using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Linq;
using CariocaMix.Utils.Resources;
using CariocaMix.CrossCutting.Interfaces;

namespace CariocaMix.Utils.Email
{
    public class SendEmail
    {
        private static IConfigurationHelper _config;

        public SendEmail(IConfigurationHelper config)
        {
            _config = config;
        }

        private static UserEmail GetUserEmail()
        {
            var userEmail = new UserEmail()
            {
                Username = _config.GetString("SmtpEmail:Username"),
                Password = _config.GetString("SmtpEmail:Password")
            };

            return userEmail;
        }

        public static void SendOneEmail(string subject, string body, string recipient)
        {
            var userEmail = GetUserEmail();

            var smtpClient = new SmtpClient(Texts.SMTP_EMAIL)
            {
                Port = 587,
                Credentials = new NetworkCredential(userEmail.Username, userEmail.Password),
                EnableSsl = false,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(userEmail.Username),
                Subject = subject,
                Body = body,
                IsBodyHtml = true,
            };
            mailMessage.To.Add(recipient);

            smtpClient.Send(mailMessage);
        }

        public static void SendListEmail(string subject, string body, List<string> recipients)
        {
            var userEmail = GetUserEmail();

            var smtpClient = new SmtpClient(Texts.SMTP_EMAIL)
            {
                Port = 587,
                Credentials = new NetworkCredential(userEmail.Username, userEmail.Password),
                EnableSsl = false,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(userEmail.Username),
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
