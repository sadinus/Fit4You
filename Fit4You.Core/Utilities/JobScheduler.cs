using System;
using System.Collections.Generic;
using System.Text;
using Quartz;
using Quartz.Impl;

namespace Fit4You.Core.Utilities
{
    public static class JobScheduler
    {
        public static async void Start()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            IScheduler scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<NewsletterJob>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithDailyTimeIntervalSchedule
                  (s =>
                     s.WithIntervalInHours(24)
                    .OnMondayThroughFriday()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(11, 20))
                  )
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
