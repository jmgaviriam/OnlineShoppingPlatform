using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using MongoDB.Driver;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.Infrastructure.Entity;
using Users.Infrastructure.Interface;
using Users.UseCase.Gateway.Repository;

namespace Users.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IMongoCollection<ProductMongo> _collection;
        private readonly IMapper _mapper;

        public ProductRepository(IContext context, IMapper mapper)
        {
            _collection = context.Products;
            _mapper = mapper;
        }


        public async Task<Product> GetProductById(string id)
        {
            var product = await _collection.Find(x => x.ProductId == id && x.IsDeleted == false).FirstOrDefaultAsync();
            Guard.Against.Null(product, nameof(product), $"No product found with ID '{id}'");
            return _mapper.Map<Product>(product);
        }

        public async Task<CreateProduct> CreateProduct(CreateProduct product)
        {
            var productToCreate = _mapper.Map<ProductMongo>(product);
            productToCreate.IsDeleted = false;
            await _collection.InsertOneAsync(productToCreate);
            return product;
        }

        public async Task<CreateProduct> UpdateProduct(UpdateProduct product)
        {
            var productToUpdate = _mapper.Map<ProductMongo>(product);
            var productUpdated = await _collection.FindOneAndReplaceAsync(x => x.ProductId == product.ProductId && x.IsDeleted == false, productToUpdate);
            Guard.Against.Null(productUpdated, nameof(productUpdated), $"No product found with ID '{product.ProductId}'");
            return _mapper.Map<CreateProduct>(productToUpdate);
        }

        public async Task<Product> DeleteProduct(string id)
        {
            var productToUpdate = await _collection.FindOneAndUpdateAsync(
                x => x.ProductId == id && !x.IsDeleted,
                Builders<ProductMongo>.Update.Set(x => x.IsDeleted, true));

            Guard.Against.Null(productToUpdate, nameof(productToUpdate), $"No product found with ID '{id}'");

            return _mapper.Map<Product>(productToUpdate);
        }

        public async Task<List<Product>> GetProductsByStoreId(string id)
        {
            var products = await _collection.Find(x => x.StoreId == id && x.IsDeleted == false).ToListAsync();
            return _mapper.Map<List<Product>>(products);
        }

        public async Task UpdateQuantityOfProductsPerSupplierPurchase(string id, int quantity)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));
            Guard.Against.NegativeOrZero(quantity, nameof(quantity));

            var product = await _collection.Find(x => x.ProductId == id && x.IsDeleted == false).FirstOrDefaultAsync();
            Guard.Against.Null(product, nameof(product), $"No product found with ID '{id}'");

            var filter = Builders<ProductMongo>.Filter.Eq(x => x.ProductId, id) & Builders<ProductMongo>.Filter.Eq(x => x.IsDeleted, false);
            var update = Builders<ProductMongo>.Update.Inc(x => x.Quantity, quantity);

            await _collection.UpdateOneAsync(filter, update);
        }

        public async Task UpdateQuantityOfProductsPerCustomerSale(string id, int quantity)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));
            Guard.Against.NegativeOrZero(quantity, nameof(quantity));

            var product = await _collection.Find(x => x.ProductId == id && x.IsDeleted == false).FirstOrDefaultAsync();
            Guard.Against.Null(product, nameof(product), $"No product found with ID '{id}'");

            Guard.Against.OutOfRange(quantity, nameof(quantity), 1, product.Quantity,
                $"Quantity must be between 1 and {product.Quantity}.");

            var filter = Builders<ProductMongo>.Filter.Eq(x => x.ProductId, id) & Builders<ProductMongo>.Filter.Eq(x => x.IsDeleted, false);
            var update = Builders<ProductMongo>.Update.Inc(x => x.Quantity, -quantity);
            await _collection.UpdateOneAsync(filter, update);
        }

    }
}
