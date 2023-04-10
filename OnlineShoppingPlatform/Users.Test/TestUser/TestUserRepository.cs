using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway.Repository;

namespace Users.Test.TestUser
{
    public class TestUserRepository
    {
        private readonly Mock<IUserRepository> _mockUserRepository;

        public TestUserRepository()
        {
            _mockUserRepository = new();
        }

        [Fact]
        public async Task GetUserById()
        {
            // Arrange
            var user = new User
            {
                UserId = "1",
                FirstName = "Test",
                LastName = "User",
                Email = "email",
                Password = "password",
                Role = "role"
            };

            _mockUserRepository.Setup(x => x.GetUserById(It.IsAny<string>())).ReturnsAsync(user);

            // Act
            var result = await _mockUserRepository.Object.GetUserById("1");

            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task CreateUser()
        {
            // Arrange
            var user = new CreateUser
            {
                FirstName = "Test",
                LastName = "User",
                Email = "email",
                Password = "password",
                Role = "role"
            };
            _mockUserRepository.Setup(x => x.CreateUser(It.IsAny<CreateUser>())).ReturnsAsync(user);
            // Act
            var result = await _mockUserRepository.Object.CreateUser(user);
            // Assert
            Assert.Equal(user, result);
        }

        [Fact]
        public async Task UpdateUser()
        {
            // Arrange
            var user = new UpdateUser
            {
                UserId = "1",
                FirstName = "Test",
                LastName = "User",
                Email = "email",
                Password = "password",
                Role = "role"
            };

            var userUpdated = new CreateUser
            {
                FirstName = "Test",
                LastName = "User",
                Email = "email",
                Password = "password",
                Role = "role"
            };

            _mockUserRepository.Setup(x => x.UpdateUser(It.IsAny<UpdateUser>())).ReturnsAsync(userUpdated);
            // Act
            var result = await _mockUserRepository.Object.UpdateUser(user);
            // Assert
            Assert.Equal(userUpdated, result);
        }

        [Fact]
        public async Task DeleteUser()
        {
            // Arrange
            var user = new User
            {
                UserId = "1",
                FirstName = "Test",
                LastName = "User",
                Email = "email",
                Password = "password",
                Role = "role"
            };
            _mockUserRepository.Setup(x => x.DeleteUser(It.IsAny<string>())).ReturnsAsync(user);
            // Act
            var result = await _mockUserRepository.Object.DeleteUser("1");
            // Assert
            Assert.Equal(user, result);
        }
    }
}
