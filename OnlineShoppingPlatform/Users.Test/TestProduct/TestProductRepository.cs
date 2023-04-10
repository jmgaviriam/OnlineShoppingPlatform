using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoMapper;
using MongoDB.Driver;
using Moq;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.Infrastructure.Entity;
using Users.Infrastructure.Repository;
using Users.UseCase.Gateway.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace Users.Test.TestProduct
{
    public class TestProductRepository
    {
        private readonly Mock<IProductRepository> _mockProductRepository;

        public TestProductRepository()
        {
            _mockProductRepository = new();
        }

        [Fact]
        public async Task GetProductById()
        {
            //Arrange
            var product = new Product
            {
                ProductId = "1",
                StoreId = "1",
                Name = "Test",
                Description = "Test",
                Image = "Test",
                Price = 1,
                Quantity = 1

            };


            _mockProductRepository.Setup(x => x.GetProductById(It.IsAny<string>())).ReturnsAsync(product);

            //Act
            var result = await _mockProductRepository.Object.GetProductById("1");

            //Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public async Task CreateProduct()
        {
            //Arrange
            var product = new CreateProduct
            {
                StoreId = "1",
                Name = "Test",
                Description = "Test",
                Image = "Test",
                Price = 1,
                Quantity = 1
            };
            _mockProductRepository.Setup(x => x.CreateProduct(It.IsAny<CreateProduct>())).ReturnsAsync(product);
            //Act
            var result = await _mockProductRepository.Object.CreateProduct(product);
            //Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public async Task UpdateProduct()
        {
            //Arrange
            var product = new UpdateProduct
            {
                ProductId = "1",
                StoreId = "1",
                Name = "Test",
                Description = "Test",
                Image = "Test",
                Price = 1,
                Quantity = 1
            };

            var productUpdated = new CreateProduct
            {
                StoreId = "1",
                Name = "Test",
                Description = "Test",
                Image = "Test",
                Price = 1,
                Quantity = 1
            };

            _mockProductRepository.Setup(x => x.UpdateProduct(It.IsAny<UpdateProduct>())).ReturnsAsync(productUpdated);
            //Act
            var result = await _mockProductRepository.Object.UpdateProduct(product);
            //Assert
            Assert.Equal(productUpdated, result);
        }

        [Fact]
        public async Task DeleteProduct()
        {
            //Arrange
            var product = new Product
            {
                ProductId = "1",
                StoreId = "1",
                Name = "Test",
                Description = "Test",
                Image = "Test",
                Price = 1,
                Quantity = 1
            };
            _mockProductRepository.Setup(x => x.DeleteProduct(It.IsAny<string>())).ReturnsAsync(product);
            //Act
            var result = await _mockProductRepository.Object.DeleteProduct("1");
            //Assert
            Assert.Equal(product, result);
        }

        [Fact]
        public async Task GetProductsByStoreId()
        {
            //Arrange
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = "1",
                    StoreId = "1",
                    Name = "Test",
                    Description = "Test",
                    Image = "Test",
                    Price = 1,
                    Quantity = 1
                },
                new Product
                {
                    ProductId = "2",
                    StoreId = "1",
                    Name = "Test",
                    Description = "Test",
                    Image = "Test",
                    Price = 1,
                    Quantity = 1
                }
            };
            _mockProductRepository.Setup(x => x.GetProductsByStoreId(It.IsAny<string>())).ReturnsAsync(products);
            //Act
            var result = await _mockProductRepository.Object.GetProductsByStoreId("1");
            //Assert
            Assert.Equal(products, result);
        }

        [Fact]
        public async Task UpdateQuantityOfProductsPerSupplierPurchase()
        {
            //Arrange 
            string id = "1";
            int quantity = 1;

            _mockProductRepository.Setup(x => x.UpdateQuantityOfProductsPerSupplierPurchase(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync("1");

            //Act
            var result = await _mockProductRepository.Object.UpdateQuantityOfProductsPerSupplierPurchase(id, quantity);

            //Assert
            Assert.Equal("1", result);
        }


        [Fact]
        public async Task UpdateQuantityOfProductsPerSupplierSale()
        {
            //Arrange
            string id = "1";
            int quantity = 1;

            _mockProductRepository.Setup(x => x.UpdateQuantityOfProductsPerCustomerSale(It.IsAny<string>(), It.IsAny<int>())).ReturnsAsync("1");

            //Act
            var result = await _mockProductRepository.Object.UpdateQuantityOfProductsPerCustomerSale(id, quantity);

            //Assert
            Assert.Equal("1", result);
        }
    }
}
