using System;
using Fit4You.Core.BackgroundTasks;
using Fit4You.Core.Services.Mail;
using Fit4You.Core.Utilities;
using Moq;
using Xunit;

namespace Fit4You.Tests
{
    public class ScopedMailServiceTests
    {
        [Theory]
        [InlineData(DayOfWeek.Monday)]
        [InlineData(DayOfWeek.Tuesday)]
        [InlineData(DayOfWeek.Wednesday)]
        [InlineData(DayOfWeek.Thursday)]
        [InlineData(DayOfWeek.Friday)]
        public void SendNewsletterToSubscribedUsers_DuringWorkingDays_ShouldWork(DayOfWeek dayOfWeek)
        {
            var mockMailService = new Mock<IMailService>();

            Mock<IDateTimeProvider> stubDateTimeProvider = new Mock<IDateTimeProvider>();
            stubDateTimeProvider.Setup(x => x.DayOfWeek()).Returns(dayOfWeek);

            var sut = new ScopedMailService(mockMailService.Object, stubDateTimeProvider.Object);

            sut.DoWork();

            mockMailService.Verify(x => x.SendTestMail(), Times.Once);
        }

        [Theory]
        [InlineData(DayOfWeek.Saturday)]
        [InlineData(DayOfWeek.Sunday)]
        public void SendNewsletterToSubscribedUsers_DuringWeekend_ShouldFail(DayOfWeek dayOfWeek)
        {
            var mockMailService = new Mock<IMailService>();

            Mock<IDateTimeProvider> stubDateTimeProvider = new Mock<IDateTimeProvider>();
            stubDateTimeProvider.Setup(x => x.DayOfWeek()).Returns(dayOfWeek);

            var sut = new ScopedMailService(mockMailService.Object, stubDateTimeProvider.Object);

            sut.DoWork();

            mockMailService.Verify(x => x.SendTestMail(), Times.Never);
        }
    }
}
