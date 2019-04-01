using Fit4You.Core.Data;
using Fit4You.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fit4You.Core.BackgroundTasks
{
    public class ConsumeScopedMailService : IHostedService
    {
        private Timer timer;
        public IServiceProvider Services { get; }

        public ConsumeScopedMailService(IServiceProvider services)
        {
            Services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var startTimeSpan = GetStartTimeSpan();
            var periodTimeSpan = TimeSpan.FromDays(1);

            timer = new Timer(DoWork, null, startTimeSpan, periodTimeSpan);

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var now = DateTime.Now;

            using (var scope = Services.CreateScope())
            {
                var scopedMailService = scope.ServiceProvider.GetRequiredService<IScopedMailService>();
                scopedMailService.DoWork();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();
        }

        private TimeSpan GetStartTimeSpan()
        {
            var currentTime = DateTime.Now.Ticks;
            var executeTime = DateTime.Today.AddHours(17)
                                            .AddMinutes(22)
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
