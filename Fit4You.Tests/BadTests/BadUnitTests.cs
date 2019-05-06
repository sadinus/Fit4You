using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using Fit4You.Core.BackgroundTasks;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;
using Fit4You.Core.Repositories;
using Fit4You.Core.Services;
using Fit4You.Core.Services.Mail;
using Moq;
using Xunit;

namespace Fit4You.Tests.BadTests
{
    public class BadUnitTests
    {
        [Fact]
        public void BMRCalculation()
        {
            var calculator = new CalculatorService();

            var actual = calculator.CalculateBMR(82, 189, 26, true);

            Assert.Equal(1876.25, actual);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void CalculateBMR_ForMaleOrFemale_ShouldWork(bool isMale)
        {
            var calculator = new CalculatorService();
            double expected;

            if (isMale)
            {
                expected = 1445;
            }
            else
            {
                expected = 1279;
            }

            var actual = calculator.CalculateBMR(55, 160, 22, isMale);

            Assert.True(expected == actual);
        }

        [Fact]
        public void CalculateBMR_ForFemale_ShouldWork()
        {
            var calculator = new CalculatorService();
            var expected = 1279;

            var actual = calculator.CalculateBMR(55, 160, 22, false);

            Assert.True(expected == actual, "Calculated BMR for female is not equal to expected.");
        }

        [Fact]
        public void CalculateBMI_HeightIsZero_ReturnsZero()
        {
            var expected = 0;
            var calculator = new CalculatorService();

            Assert.Equal(calculator.CalculateBMI(20, 0), expected);
        }

        [Fact]
        public void CalculateBMI_NegativeParameters_ReturnsPositiveResult()
        {
            var calculator = new CalculatorService();

            var data = new List<(int weight, int height)>()
            {
                (-1,  1 ),
                ( 1, -1 ),
                (-1, -1 ),
                ( 1,  1 )
            };

            foreach (var testCase in data)
            {
                var actual = calculator.CalculateBMI(testCase.weight, testCase.height);
                Assert.True(actual > 0);
            }
        }

        [Fact]
        public void Add_NewUser_ShouldWork()
        {
            var newUser = new User
            {
                Id = 0,
                Email = "newuser@gmail.com",
                PasswordHash = "Password"
            };

            var userRepository = new FakeUserRepository();

            var beforeAdd = userRepository.FindAll().Count();

            userRepository.Add(newUser);

            var afterAdd = userRepository.FindAll().Count();

            Assert.Equal(beforeAdd + 1, afterAdd);
        }

        [Fact]
        public void GetById_ForExistingUser_ShouldWork()
        {
            List<User> users = new List<User>
                {
                    new User { Id = 1, Email = "test@gmail.com", PasswordHash = "Password"},
                    new User { Id = 2, Email = "bigbob@yahoo.com", PasswordHash = "Password1"},
                    new User { Id = 3, Email = "johndoe@gmail.com", PasswordHash = "Password2" },
                };

            var expected = new User
            {
                Id = 1,
                Email = "test@gmail.com",
                PasswordHash = "Password"
            };

            var stubUserRepository = new Mock<IUserRepository>();

            stubUserRepository.Setup(x => x.GetById(
                It.IsAny<int>())).Returns((int id) => users.SingleOrDefault(x => x.Id == id));

            var stubObject = stubUserRepository.Object;

            var actual = stubObject.GetById(expected.Id);

            Assert.Equal(actual.Email, expected.Email);
            Assert.Equal(actual.PasswordHash, expected.PasswordHash);
        }

        [Fact]
        public void SendNewsletterToSubscribedUsers_DuringWorkingDays_ShouldWork()
        {
            var mockMailService = new Mock<IMailService>();

            var sut = new ScopedMailService(mockMailService.Object);

            sut.DoWork(DateTime.Now.DayOfWeek);

            mockMailService.Verify(x => x.SendTestMail(), Times.Once);
        }

        [Fact]
        public void SendMail_ForAnyMessage_ReturnsCorrectBody()
        {
            // Arrange
            var mockSmtpClient = new Mock<ISmtpClient>();
            mockSmtpClient.Setup(x => x.SendMail(
                It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                    .Returns((string email, string subject, string body) => new MailMessage("test@o2.pl", email, subject, body));

            var sut = mockSmtpClient.Object;

            const string EMAIL = "test@gmail.com";
            const string SUBJECT = "Test Mesage";
            const string BODY = "This is a test";

            var expected = "This is a test";

            // Act
            var message = sut.SendMail(EMAIL, SUBJECT, BODY);

            // Assert
            Assert.Equal(expected, message.Body);
        }
    }
}
