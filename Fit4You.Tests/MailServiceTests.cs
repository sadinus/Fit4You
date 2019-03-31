using Fit4You.Core.Services.Mail;
using Fit4You.Core.Utilities;
using Moq;
using System;
using Xunit;

namespace Fit4You.Tests
{
    public class MailServiceTests
    {
        public MailServiceTests()
        {
            Mock<IMailService> mockMailService = new Mock<IMailService>();

            this.MockScopedMailService = mockMailService.Object;
        }

        public readonly IMailService MockScopedMailService;

        [Theory]
        [InlineData(DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Tuesday)]
        [InlineData(DayOfWeek.Wednesday)]
        [InlineData(DayOfWeek.Thursday)]
        [InlineData(DayOfWeek.Friday)]
        public void SendNewsletterToSubscribedUsers_DuringWorkingDays_ShouldWork(DayOfWeek dayOfWeek)
        {
            Mock<IDateTimeProvider> stubDateTimeProvider = new Mock<IDateTimeProvider>();
            stubDateTimeProvider.Setup(x => x.DayOfWeek())
                .Returns((DayOfWeek d) => dayOfWeek);

            Mock<ISmtpClient> mockSmtpClient = new Mock<ISmtpClient>();
            EmailHelper emailHelper = new EmailHelper(mockSmtpClient.Object);

            MockScopedMailService.SendNewsletterToSubscribedUsers();

            Assert.True(fakeClient.MailSent);
        }

        [Theory]
        [InlineData(DayOfWeek.Saturday)]
        [InlineData(DayOfWeek.Sunday)]
        public void SendNewsletterToSubscribedUsers_DuringWeekend_ShouldFail(DayOfWeek dayOfWeek)
        {
            Mock<IDateTimeProvider> mockDateTimeProvider = new Mock<IDateTimeProvider>();
            mockDateTimeProvider.Setup(x => x.DayOfWeek())
                .Returns((DayOfWeek d) => dayOfWeek);

            MockScopedMailService.SendNewsletterToSubscribedUsers();
        }
    }
}
