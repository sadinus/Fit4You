using Fit4You.Core.Services.Mail;
using Fit4You.Core.Utilities;
using System;

namespace Fit4You.Core.BackgroundTasks
{
    public class ScopedMailService : IScopedMailService
    {
        private readonly IMailService mailService;
        private readonly IDateTimeProvider dateTimeProvider;

        public ScopedMailService(IMailService mailService, IDateTimeProvider dateTimeProvider)
        {
            this.mailService = mailService;
            this.dateTimeProvider = dateTimeProvider;
        }

        public ScopedMailService(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public void DoWork()
        {
            var dayOfWeek = dateTimeProvider.DayOfWeek();
            if (!IsWeekend(dayOfWeek))
            {
                mailService.SendNewsletterToSubscribedUsers();
                //mailService.SendTestMail();
            }
        }

        public void DoWork(DayOfWeek dayOfWeek)
        {
            if (!IsWeekend(dayOfWeek))
            {
                mailService.SendNewsletterToSubscribedUsers();
                //mailService.SendTestMail();
            }
        }

        private bool IsWeekend(DayOfWeek dayOfWeek)
        {
            return dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
        }
    }
}
