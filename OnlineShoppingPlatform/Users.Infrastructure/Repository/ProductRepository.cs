﻿using System;
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
            var product = await _collection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            Guard.Against.Null(product, nameof(product), $"No product found with ID '{id}'");
            return _mapper.Map<Product>(product);

        }

        public async Task<CreateProduct> CreateProduct(CreateProduct product)
        {
            var productToCreate = _mapper.Map<ProductMongo>(product);
            await _collection.InsertOneAsync(productToCreate);
            return product;
        }

        public async Task<CreateProduct> UpdateProduct(UpdateProduct product)
        {
            var productToUpdate = _mapper.Map<ProductMongo>(product);
            var productUpdated = await _collection.FindOneAndReplaceAsync(x => x.ProductId == product.ProductId, productToUpdate);
            Guard.Against.Null(productUpdated, nameof(productUpdated),
                               $"No product found with ID '{product.ProductId}'");
            return _mapper.Map<CreateProduct>(productToUpdate);
        }

        public async Task<Product> DeleteProduct(string id)
        {
            var productToDelete = await _collection.FindOneAndDeleteAsync(x => x.ProductId == id);
            Guard.Against.Null(productToDelete, nameof(productToDelete),
                                              $"No product found with ID '{id}'");
            return _mapper.Map<Product>(productToDelete);
        }
    }
}
