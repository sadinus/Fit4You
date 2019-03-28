using Fit4You.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fit4You.Core.Utilities
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
            mailService.SendNewsletterToSubscribedUsers();
        }
    }
}
