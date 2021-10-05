using CariocaMix.CrossCutting.Interfaces;
using CariocaMix.Utils.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace CariocaMix.Utils.Email
{
    public class SendEmail : ISendEmail
    {
        private static IConfigurationHelper _configurationHelper;

        public SendEmail(IConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }

        private static UserEmail GetUserEmail()
        {
            var userEmail = new UserEmail()
            {
                Username = _configurationHelper.GetString("SmtpEmail:Username"),
                Password = _configurationHelper.GetString("SmtpEmail:Password")
            };

            return userEmail;
        }

        public void SendOneEmail(string subject, string body, string recipient)
        {
            try
            {
                var userEmail = GetUserEmail();

                var smtpClient = new SmtpClient(Texts.SMTP_EMAIL)
                {
                    Port = 587,
                    Credentials = new NetworkCredential(userEmail.Username, userEmail.Password),
                    EnableSsl = true
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
            catch (Exception ex)
            {

            }
        }

        public void SendListEmail(string subject, string body, List<string> recipients)
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
