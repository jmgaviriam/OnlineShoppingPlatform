using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway;

namespace Users.Api.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductUseCase _productUseCase;
        private readonly IMapper _mapper;

        public ProductController(IProductUseCase productUseCase, IMapper mapper)
        {
            _productUseCase = productUseCase;
            _mapper = mapper;
        }

        [EnableCors("AllowAllHeaders")]
        [HttpGet]
        public async Task<Product> GetProductById(string id)
        {
            return await _productUseCase.GetProductById(id);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPost]
        public async Task<CreateProduct> CreateProduct(CreateProduct product)
        {
            return await _productUseCase.CreateProduct(product);
        }

        [EnableCors("AllowAllHeaders")]
        [HttpPut]
        public async Task<CreateProduct> UpdateProduct(UpdateProduct product)
        {
            return await _productUseCase.UpdateProduct(product);
        }

        [HttpDelete]
        public async Task<Product> DeleteProduct(string id)
        {
            return await _productUseCase.DeleteProduct(id);
        }

        [HttpGet("productsbystore/{id}")]
        public async Task<List<Product>> GetProductByStoreId(string id)
        {
            return await _productUseCase.GetProductsByStoreId(id);
        }

        [HttpPut("supplierpurchase/{id}")]
        public async Task<string> UpdateQuantityOfProductsPerSupplierPurchase(string id, int quantity)
        {
            return await _productUseCase.UpdateQuantityOfProductsPerSupplierPurchase(id, quantity);
        }

        [HttpPut("customersale/{id}")]
        public async Task<string> UpdateQuantityOfProductsPerCustomerSale(string id, int quantity)
        {
            return await _productUseCase.UpdateQuantityOfProductsPerCustomerSale(id, quantity);
        }

    }
}
