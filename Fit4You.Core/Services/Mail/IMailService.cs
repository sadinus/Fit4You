using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Services.Mail
{
    public interface IMailService
    {
        void SendNewsletterToSubscribedUsers();
        void SendTestMail();
    }
}
