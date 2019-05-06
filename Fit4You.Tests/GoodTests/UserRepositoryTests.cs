using System.Collections.Generic;
using System.Linq;
using Fit4You.Core.Data.Repositories;
using Fit4You.Core.Domain;
using FluentAssertions;
using Moq;
using Xunit;

namespace Fit4You.Tests.GoodTests
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

            mockUserRepository.Setup(x => x.UserWithGivenEmailExists(
                It.IsAny<string>())).Returns((string s) => users.Any(
                    x => x.Email.ToLowerInvariant() == s.ToLowerInvariant()));

            mockUserRepository.Setup(x => x.GetById(
                It.IsAny<int>())).Returns((int id) => users.FirstOrDefault(
                    x => x.Id == id));

            mockUserRepository.Setup(x => x.Add(
                It.IsAny<User>())).Callback((User user) => users.Add(user));

            mockUserRepository.Setup(x => x.FindAll()).Returns(users);

            this.MockUserRepository = mockUserRepository.Object;
        }

        public readonly IUserRepository MockUserRepository;


        [Theory]
        [InlineData("test@gmail.com")]
        public void UserWithGivenEmailExists_ForExistingUser_ShouldWork(string email)
        {
            var actual = MockUserRepository.UserWithGivenEmailExists(email);

            Assert.True(actual);
        }

        [Fact]
        public void GetById_ForExistingUser_ShouldWork()
        {
            var expected = new User {
                Id = 1,
                Email = "test@gmail.com",
                PasswordHash = "Password" };

            var actual = MockUserRepository.GetById(expected.Id);

            actual.Should().BeEquivalentTo(expected, options =>
                options.Excluding(x => x.UserInfo));
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

            var beforeAdd = MockUserRepository.FindAll().Count();

            MockUserRepository.Add(newUser);

            var afterAdd = MockUserRepository.FindAll().Count();

            Assert.Equal(beforeAdd + 1, afterAdd);
        }
    }
}
