using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway.Repository;

namespace Orders.Test.TestOrder
{
    public class TestOrderRepository
    {
        private readonly Mock<IOrderRepository> _mockOrderRepository;

        public TestOrderRepository()
        {
            _mockOrderRepository = new();
        }

        [Fact]
        public async Task GetOrderById()
        {
            //Arrange
            var id = "1";
            var order = new CreateOrder
            {

                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };
            _mockOrderRepository.Setup(x => x.GetOrderById(id)).ReturnsAsync(order);

            //Act
            var result = await _mockOrderRepository.Object.GetOrderById(id);

            //Assert
            Assert.Equal(order, result);
        }

        [Fact]
        public async Task CreateOrder()
        {
            //Arrange
            var order = new CreateOrder
            {
                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };

            var orderCreated = new CreateOrder
            {
                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };

            _mockOrderRepository.Setup(x => x.CreateOrder(order)).ReturnsAsync(orderCreated);

            //Act
            var result = await _mockOrderRepository.Object.CreateOrder(order);

            //Assert
            Assert.Equal(orderCreated, result);
        }


        [Fact]
        public async Task UpdateOrder()
        {
            //Arrange
            var order = new UpdateOrder
            {
                OrderId = "1",
                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };
            var orderUpdated = new CreateOrder
            {
                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };
            _mockOrderRepository.Setup(x => x.UpdateOrder(order)).ReturnsAsync(orderUpdated);
            //Act
            var result = await _mockOrderRepository.Object.UpdateOrder(order);
            //Assert
            Assert.Equal(orderUpdated, result);
        }

        [Fact]
        public async Task GetOrdersByUserId()
        {
            //Arrange
            var userId = "1";
            var orders = new List<CreateOrder>
            {
                new CreateOrder
                {
                    UserId = "1",
                    PaymentId = "1",
                    OrderDate = DateTime.Now,
                    ShippingDate = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    ShippingAddress = "Test Address",
                    TotalAmount = 100,
                    Status = "Test Status"
                },
                new CreateOrder
                {
                    UserId = "1",
                    PaymentId = "1",
                    OrderDate = DateTime.Now,
                    ShippingDate = DateTime.Now,
                    DeliveryDate = DateTime.Now,
                    ShippingAddress = "Test Address",
                    TotalAmount = 100,
                    Status = "Test Status"
                }
            };

            _mockOrderRepository.Setup(x => x.GetOrdersByUserId(userId)).ReturnsAsync(orders);

            //Act
            var result = await _mockOrderRepository.Object.GetOrdersByUserId(userId);

            //Assert
            Assert.Equal(orders, result);

        }

        [Fact]
        public async Task UpdateOrderStatus()
        {
            //Arrange
            var id = "1";
            var status = "Test Status";
            var statusUpdated = "Update successful";

            var orderUpdated = new CreateOrder
            {
                UserId = "1",
                PaymentId = "1",
                OrderDate = DateTime.Now,
                ShippingDate = DateTime.Now,
                DeliveryDate = DateTime.Now,
                ShippingAddress = "Test Address",
                TotalAmount = 100,
                Status = "Test Status"
            };

            _mockOrderRepository.Setup(x => x.UpdateOrderStatus(id, status)).ReturnsAsync(statusUpdated);

            //Act
            var result = await _mockOrderRepository.Object.UpdateOrderStatus(id, status);

            //Assert
            Assert.Equal(statusUpdated, result);
        }
    }
}
