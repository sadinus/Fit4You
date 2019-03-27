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
            mailService.SendNewsletterToSubscribedUsers();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
