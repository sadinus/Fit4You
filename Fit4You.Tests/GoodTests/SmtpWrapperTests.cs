using System;
using System.Collections.Generic;
using System.Text;
using Fit4You.Core.Services.Mail;
using Xunit;
using Moq;
using System.Net.Mail;

namespace Fit4You.Tests.GoodTests
{
    public class SmtpWrapperTests
    {
        public SmtpWrapperTests()
        {
            var mockSmtpClient = new Mock<ISmtpClient>();
            mockSmtpClient.Setup(x => x.SendMail(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                    .Returns((string email, string subject, string body) => 
                        new MailMessage("test@o2.pl", email, subject, body));

            this.MockSmtpClient = mockSmtpClient.Object;
        }

        public readonly ISmtpClient MockSmtpClient;

        [Fact]
        public void SendMail_ForAnyMessage_ReturnsCorrectBody()
        {
            const string EMAIL = "test@gmail.com";
            const string SUBJECT = "Test Mesage";
            const string BODY = "This is a test";
            var expected = "test";

            var message = MockSmtpClient.SendMail(EMAIL, SUBJECT, BODY);

            Assert.Contains(expected, message.Body);
        }
    }
}
