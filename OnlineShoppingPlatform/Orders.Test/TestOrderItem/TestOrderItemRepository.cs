using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway.Repository;

namespace Orders.Test.TestOrderItem
{
    public class TestOrderItemRepository
    {
        private readonly Mock<IOrderItemRepository> _mockOrderItemRepository;

        public TestOrderItemRepository()
        {
            _mockOrderItemRepository = new();
        }

        [Fact]
        public async Task GetOrderItemById()
        {
            //Arrange
            var id = "1";
            var orderItem = new CreateOrderItem
            {
                OrderId = "1",
                ProductId = "1",
                Quantity = 1,
                Price = 100
            };
            _mockOrderItemRepository.Setup(x => x.GetOrderItemById(id)).ReturnsAsync(orderItem);
            //Act
            var result = await _mockOrderItemRepository.Object.GetOrderItemById(id);
            //Assert
            Assert.Equal(orderItem, result);
        }

        [Fact]
        public async Task CreateOrderItem()
        {
            //Arrange
            var orderItem = new CreateOrderItem
            {
                OrderId = "1",
                ProductId = "1",
                Quantity = 1,
                Price = 100
            };
            _mockOrderItemRepository.Setup(x => x.CreateOrderItem(orderItem)).ReturnsAsync(orderItem);
            //Act
            var result = await _mockOrderItemRepository.Object.CreateOrderItem(orderItem);
            //Assert
            Assert.Equal(orderItem, result);
        }

        [Fact]
        public async Task UpdateOrderItem()
        {
            //Arrange
            var orderItem = new UpdateOrderItem()
            {
                OrderItemId = "1",
                OrderId = "1",
                ProductId = "1",
                Quantity = 1,
                Price = 100
            };

            var orderItemUpdated = new CreateOrderItem()
            {
                OrderId = "1",
                ProductId = "1",
                Quantity = 1,
                Price = 100
            };

            _mockOrderItemRepository.Setup(x => x.UpdateOrderItem(orderItem)).ReturnsAsync(orderItemUpdated);

            //Act
            var result = await _mockOrderItemRepository.Object.UpdateOrderItem(orderItem);

            //Assert
            Assert.Equal(orderItemUpdated, result);
        }

        [Fact]
        public async Task DeleteOrderItem()
        {
            //Arrange
            var id = "1";
            var orderItem = new CreateOrderItem
            {
                OrderId = "1",
                ProductId = "1",
                Quantity = 1,
                Price = 100
            };


            _mockOrderItemRepository.Setup(x => x.DeleteOrderItem(id)).ReturnsAsync(orderItem);
            //Act
            var result = await _mockOrderItemRepository.Object.DeleteOrderItem(id);
            //Assert
            Assert.Equal(orderItem, result);
        }
    }
}
