using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.DTO;
using Users.Domain.Entity;

namespace Users.UseCase.Gateway
{
    public interface IProductUseCase
    {
        Task<Product> GetProductById(string id);
        Task<CreateProduct> CreateProduct(CreateProduct product);
        Task<CreateProduct> UpdateProduct(UpdateProduct product);
        Task<Product> DeleteProduct(string id);
        Task<List<Product>> GetProductsByStoreId(string id);
        Task<string> UpdateQuantityOfProductsPerSupplierPurchase(string id, int quantity);
        Task<string> UpdateQuantityOfProductsPerCustomerSale(string id, int quantity);
    }
}
