using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using Fit4You.Core.Data;

namespace Fit4You.Core.Services
{
    public class MailService : IMailService
    {
        private readonly IUnitOfWork unitOfWork;
        public MailService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void SendNewsletterToSubscribedUsers()
        {
            var users = unitOfWork.UserRepository.FindUsersWithSubscription();

            SendNewsletterMail("p_pindelski@o2.pl");

            //foreach (var user in users)
            //{
            //    SendNewsletterMail(user.Email);
            //}
        }

        private void SendNewsletterMail(string email)
        {
            var fromAddress = new MailAddress("fit4youmail@gmail.com", "Fit4You");
            var toAddress = new MailAddress(email);
            const string fromPassword = "Fit4YouMail";
            const string subject = "Newsletter";
            const string body = "Hi,<br>Here is out newsletter that you are currently signed in.<br><br>Best Regards<br>Fit4You Team";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
            {
                smtp.Send(message);
            }
        }
    }
}
