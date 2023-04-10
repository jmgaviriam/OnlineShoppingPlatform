using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway.Repository;

namespace Users.Test.TestStore
{
    public class TestStoreRepository
    {
        private readonly Mock<IStoreRepository> _mockStoreRepository;

        public TestStoreRepository()
        {
            _mockStoreRepository = new();
        }

        [Fact]
        public async Task GetStoreById()
        {
            // Arrange
            var storeId = "123";
            var store = new Store
            {
                StoreId = storeId,
                UserId = "Test store",
                Name = "Test Store",
                Description = "Test Store Description",
                Logo = "Test Store Logo"
            };
            _mockStoreRepository.Setup(x => x.GetStoreById(storeId)).ReturnsAsync(store);
            // Act
            var result = await _mockStoreRepository.Object.GetStoreById(storeId);
            // Assert
            Assert.Equal(store, result);
        }

        [Fact]
        public async Task CreateStore()
        {
            // Arrange
            var store = new CreateStore
            {
                UserId = "Test store",
                Name = "Test Store",
                Description = "Test Store Description",
                Logo = "Test Store Logo"
            };
            _mockStoreRepository.Setup(x => x.CreateStore(store)).ReturnsAsync(store);
            // Act
            var result = await _mockStoreRepository.Object.CreateStore(store);
            // Assert
            Assert.Equal(store, result);
        }

        [Fact]
        public async Task UpdateStore()
        {
            // Arrange
            var store = new UpdateStore
            {
                StoreId = "123",
                UserId = "Test store",
                Name = "Test Store",
                Description = "Test Store Description",
                Logo = "Test Store Logo"
            };

            var storeUpdated = new CreateStore
            {
                UserId = "Test store",
                Name = "Test Store",
                Description = "Test Store Description",
                Logo = "Test Store Logo"
            };

            _mockStoreRepository.Setup(x => x.UpdateStore(store)).ReturnsAsync(storeUpdated);
            // Act
            var result = await _mockStoreRepository.Object.UpdateStore(store);
            // Assert
            Assert.Equal(storeUpdated, result);
        }

        [Fact]
        public async Task DeleteStore()
        {
            // Arrange
            var storeId = "123";
            var store = new Store
            {
                StoreId = storeId,
                UserId = "Test store",
                Name = "Test Store",
                Description = "Test Store Description",
                Logo = "Test Store Logo"
            };
            _mockStoreRepository.Setup(x => x.DeleteStore(storeId)).ReturnsAsync(store);
            // Act
            var result = await _mockStoreRepository.Object.DeleteStore(storeId);
            // Assert
            Assert.Equal(store, result);
        }
    }
}
