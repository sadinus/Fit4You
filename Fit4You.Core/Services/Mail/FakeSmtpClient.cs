using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Fit4You.Core.Services.Mail
{
    public class FakeSmtpClient : ISmtpClient
    {
        public bool MailSent { get; set; }
        public FakeSmtpClient()
        {
            MailSent = false;
        }
        public void Send(MailMessage message)
        {
            MailSent = true;
        }
    }
}
