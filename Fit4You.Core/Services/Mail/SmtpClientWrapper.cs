using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using Fit4You.Core.Utilities;
using Microsoft.Extensions.Configuration;

namespace Fit4You.Core.Services.Mail
{
    public class SmtpClientWrapper : SmtpClient, ISmtpClient
    {
        private readonly IConfiguration config;
        private readonly IFileHelper fileHelper;

        public SmtpClientWrapper(IConfiguration config, IFileHelper fileHelper)
        {
            this.config = config;
            this.fileHelper = fileHelper;

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
                fileHelper.SaveMailLocalCopy(message.To.ToString(), message.Body);
            }
        }
    }
}
