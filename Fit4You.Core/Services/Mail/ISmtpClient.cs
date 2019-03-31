using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;

namespace Fit4You.Core.Services.Mail
{
    public interface ISmtpClient
    {
        void Send(MailMessage message);
    }
}
