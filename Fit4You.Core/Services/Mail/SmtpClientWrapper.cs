using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Fit4You.Core.Services.Mail
{
    public class SmtpClientWrapper : SmtpClient, ISmtpClient
    {
        private readonly IConfiguration config;
        public SmtpClientWrapper(IConfiguration config)
        {
            this.config = config;

            Host = config.GetValue<string>("Smtp:Host");
            Port = config.GetValue<int>("Smtp:Port");
            EnableSsl = true;
            DeliveryMethod = SmtpDeliveryMethod.Network;
            UseDefaultCredentials = false;
            Credentials = new NetworkCredential(config.GetValue<string>("Smtp:Email"), config.GetValue<string>("Smtp:Password"));
        }
        public void SendMail(string email, string subject, string body)
        {
            var fromAddress = new MailAddress(config.GetValue<string>("Smtp:Email"), config.GetValue<string>("Smtp:Username"));
            var toAddress = new MailAddress(email);

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                base.Send(message);
                SaveLocalCopyOf(message);
            }
        }

        private void SaveLocalCopyOf(MailMessage mailMessage)
        {
            var dir = @"C:/temp/smtp-spool";
            var email = mailMessage.To.ToString();
            var mailOwner = email.Substring(0, email.IndexOf('@'));
            var filename = $"email_{DateTime.Now.ToString("dd-MM-yyyy_HH:mm")}_{mailOwner}.htm";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText($@"{dir}/{filename}", mailMessage.Body, Encoding.UTF8);
        }
    }
}
