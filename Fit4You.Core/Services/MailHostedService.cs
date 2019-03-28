using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Fit4You.Core.Services
{
    public class MailHostedService : IHostedService
    {
        private readonly IMailService mailService;

        public MailHostedService(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimeSpan = GetStartTimeSpan();
            var periodTimeSpan = TimeSpan.FromDays(1);

            var timer = new System.Threading.Timer((e) =>
            {
                mailService.SendNewsletterToSubscribedUsers();
            }, null, startTimeSpan, periodTimeSpan);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private TimeSpan GetStartTimeSpan()
        {
            var currentTime = DateTime.Now.Ticks;
            var executeTime = DateTime.Today.AddHours(8)
                                            .AddMinutes(0)
                                            .Ticks;

            long ticks = executeTime - currentTime;

            if (ticks < 0)
            {
                ticks = ticks + TimeSpan.TicksPerDay;
            }

            var startTimeSpan = new TimeSpan(ticks);

            return startTimeSpan;
        }
    }
}
