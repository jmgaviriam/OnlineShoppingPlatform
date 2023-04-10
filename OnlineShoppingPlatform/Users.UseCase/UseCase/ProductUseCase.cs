using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway;
using Users.UseCase.Gateway.Repository;

namespace Users.UseCase.UseCase
{
    public class ProductUseCase : IProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public ProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await _productRepository.GetProductById(id);
        }

        public async Task<CreateProduct> CreateProduct(CreateProduct product)
        {
            return await _productRepository.CreateProduct(product);
        }

        public async Task<CreateProduct> UpdateProduct(UpdateProduct product)
        {
            return await _productRepository.UpdateProduct(product);
        }

        public async Task<Product> DeleteProduct(string id)
        {
            return await _productRepository.DeleteProduct(id);
        }

        public async Task<List<Product>> GetProductsByStoreId(string id)
        {
            return await _productRepository.GetProductsByStoreId(id);
        }

        public async Task UpdateQuantityOfProductsPerSupplierPurchase(string id, int quantity)
        {
            await _productRepository.UpdateQuantityOfProductsPerSupplierPurchase(id, quantity);
        }

        public async Task UpdateQuantityOfProductsPerCustomerSale(string id, int quantity)
        {
            await _productRepository.UpdateQuantityOfProductsPerCustomerSale(id, quantity);
        }
    }
}
