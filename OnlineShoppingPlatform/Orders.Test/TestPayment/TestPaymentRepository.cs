using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Orders.Domain.DTO;
using Orders.UseCase.Gateway.Repository;

namespace Orders.Test.TestPayment
{
    public class TestPaymentRepository
    {
        private readonly Mock<IPaymentRepository> _mockPaymentRepository;

        public TestPaymentRepository()
        {
            _mockPaymentRepository = new();
        }

        [Fact]
        public async Task GetPaymentById()
        {
            //Arrange
            var id = "123456789";
            var payment = new CreatePayment
            {
                PaymentDate = DateTime.Now,
                Amount = 100,
                PaymentMethod = "CreditCard",
                CardNumber = "123456789",
                CardHolderName = "Test",
                CVV = "123"
            };

            _mockPaymentRepository.Setup(x => x.GetPaymentById(id)).ReturnsAsync(payment);

            //Act
            var result = await _mockPaymentRepository.Object.GetPaymentById(id);

            //Assert
            Assert.Equal(payment, result);

        }

        [Fact]
        public async Task CreatePayment()
        {
            //Arrange
            var payment = new CreatePayment
            {
                PaymentDate = DateTime.Now,
                Amount = 100,
                PaymentMethod = "CreditCard",
                CardNumber = "123456789",
                CardHolderName = "Test",
                CVV = "123"
            };
            _mockPaymentRepository.Setup(x => x.CreatePayment(payment)).ReturnsAsync(payment);
            //Act
            var result = await _mockPaymentRepository.Object.CreatePayment(payment);
            //Assert
            Assert.Equal(payment, result);
        }

        [Fact]
        public async Task UpdatePayment()
        {
            //Arrange
            var payment = new UpdatePayment
            {
                PaymentId = "1",
                PaymentDate = DateTime.Now,
                Amount = 100,
                PaymentMethod = "CreditCard",
                CardNumber = "123456789",
                CardHolderName = "Test",
                CVV = "123"
            };

            var paymentUpdate = new CreatePayment
            {
                PaymentDate = DateTime.Now,
                Amount = 100,
                PaymentMethod = "CreditCard",
                CardNumber = "123456789",
                CardHolderName = "Test",
                CVV = "123"
            };
            _mockPaymentRepository.Setup(x => x.UpdatePayment(payment)).ReturnsAsync(paymentUpdate);

            //Act
            var result = await _mockPaymentRepository.Object.UpdatePayment(payment);

            //Assert
            Assert.Equal(paymentUpdate, result);
        }
    }
}
