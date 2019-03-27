using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Fit4You.Core.Services;
using Quartz;

namespace Fit4You.Core.Utilities
{
    public class NewsletterJob : IJob
    {
        private readonly IMailService mailService;

        public NewsletterJob(IMailService mailService)
        {
            this.mailService = mailService;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Task task = new Task(() => mailService.SendNewsletterToSubscribedUsers());
            task.Start();
            return task;
        }
    }
}
