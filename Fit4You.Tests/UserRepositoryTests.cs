using System.Collections.Generic;
using System.Linq;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace Fit4You.Tests
{
    public class UserRepositoryTests
    {
        public UserRepositoryTests()
        {
            List<User> users = new List<User>
                {
                    new User { Id = 1, Email = "test@gmail.com", PasswordHash = "Password"},
                    new User { Id = 2, Email = "bigbob@yahoo.com", PasswordHash = "Password1"},
                    new User { Id = 3, Email = "johndoe@gmail.com", PasswordHash = "Password2" },
                };

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(x => x.FindAll()).Returns(users);

            mockUserRepository.Setup(x => x.UserWithGivenEmailExists(
                It.IsAny<string>())).Returns((string s) => users.Any(
                    x => x.Email == s.ToLowerInvariant()));

            mockUserRepository.Setup(x => x.GetByEmail(
                It.IsAny<string>())).Returns((string s) => users.FirstOrDefault(
                    x => x.Email == s.ToLowerInvariant()));

            this.MockUserRepository = mockUserRepository.Object;
        }

        public readonly IUserRepository MockUserRepository;


        [Theory]
        [InlineData("test@gmail.com")]
        [InlineData("TestUser")]
        public void CheckCredentials_ForExistingUser_ShouldWork(string emailOrUsername)
        {
            var actual = MockUserRepository.UserWithGivenEmailExists(emailOrUsername);

            Assert.True(actual);
        }

        [Fact]
        public void GetByEmail_ForExistingUser_ShouldWork()
        {
            var expected = new User {
                Id = 1,
                Email = "test@gmail.com",
                PasswordHash = "Password" };

            var actual = MockUserRepository.GetByEmail(expected.Email);

            actual.Should().BeEquivalentTo(expected, options =>
                options.Excluding(x => x.UserInfo));
        }
    }
}
