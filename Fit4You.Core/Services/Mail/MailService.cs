using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using Fit4You.Core.Data;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Fit4You.Core.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ISmtpClient smtpClientWrapper;

        public MailService(IUnitOfWork unitOfWork, ISmtpClient smtpClientWrapper)
        {
            this.unitOfWork = unitOfWork;
            this.smtpClientWrapper = smtpClientWrapper;
        }

        public void SendTestMail()
        {
            const string subject = "Test";
            const string body = "Hi,<br>This is a test of sending emails.<br>Fit4You Team";

            smtpClientWrapper.SendMail("p_pindelski@o2.pl", subject, body);
        }

        public void SendNewsletterToSubscribedUsers()
        {
            var users = unitOfWork.UserRepository.FindUsersWithSubscription();

            foreach (var user in users)
            {
                SendNewsletterTo(user.Email);
            }
        }

        private void SendNewsletterTo(string email)
        {
            const string subject = "Newsletter";
            const string body = "Hi,<br>Here is out newsletter that you are currently signed in.<br><br>Best Regards<br>Fit4You Team";

            smtpClientWrapper.SendMail(email, subject, body);
        }
    }
}
