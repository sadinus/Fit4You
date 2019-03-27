using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fit4You.Core.Services;
using Microsoft.Extensions.Hosting;

namespace Fit4You.Core.Utilities
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
            mailService.SendNewsletterToSubscribedUsers();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
