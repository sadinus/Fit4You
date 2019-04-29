using System;
using System.Collections.Generic;
using System.Linq;
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
        public void GetByEmail_ForExistingUser_ShouldWork()
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

            stubUserRepository.Setup(x => x.GetByEmail(
                It.IsAny<string>())).Returns((string email) => users.SingleOrDefault(x => x.Email == email));

            var stubObject = stubUserRepository.Object;

            var actual = stubObject.GetByEmail(expected.Email);

            Assert.Equal(actual.Id, expected.Id);
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
    }
}
