using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.DTO;
using Users.Domain.Entity;

namespace Users.UseCase.Gateway.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetProductById(string id);
        Task<CreateProduct> CreateProduct(CreateProduct product);
        Task<CreateProduct> UpdateProduct(UpdateProduct product);
        Task<Product> DeleteProduct(string id);
    }
}
