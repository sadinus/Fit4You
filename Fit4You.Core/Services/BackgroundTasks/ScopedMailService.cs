using Fit4You.Core.Services.Mail;
using System;

namespace Fit4You.Core.BackgroundTasks
{
    public class ScopedMailService : IScopedMailService
    {
        private readonly IMailService mailService;

        public ScopedMailService(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void DoWork()
        {
            if (!IsWeekend())
            {
                mailService.SendNewsletterToSubscribedUsers();
            }
        }

        private bool IsWeekend()
        {
            return DateTime.Now.DayOfWeek == DayOfWeek.Saturday || DateTime.Now.DayOfWeek == DayOfWeek.Sunday;
        }
    }
}
