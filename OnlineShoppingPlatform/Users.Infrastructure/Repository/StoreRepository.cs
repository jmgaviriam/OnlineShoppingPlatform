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
    public class StoreRepository : IStoreRepository
    {
        private readonly IMongoCollection<StoreMongo> _collection;
        private readonly IMapper _mapper;

        public StoreRepository(IContext context, IMapper mapper)
        {
            _collection = context.Stores;
            _mapper = mapper;
        }

        public async Task<Store> GetStoreById(string id)
        {
            var store = await _collection.Find(x => x.StoreId == id).FirstOrDefaultAsync(); ;
            Guard.Against.Null(store, nameof(store), $"No store found with ID '{id}'");
            return _mapper.Map<Store>(store);
        }

        public async Task<CreateStore> CreateStore(CreateStore store)
        {
            var storeToCreate = _mapper.Map<StoreMongo>(store);
            await _collection.InsertOneAsync(storeToCreate);
            return store;
        }

        public async Task<CreateStore> UpdateStore(UpdateStore store)
        {
            var storeToUpdate = _mapper.Map<StoreMongo>(store);
            var storeUpdated = await _collection.FindOneAndReplaceAsync(x => x.StoreId == store.StoreId, storeToUpdate);
            Guard.Against.Null(storeUpdated, nameof(storeUpdated),
                               $"No store found with ID '{store.StoreId}'");
            return _mapper.Map<CreateStore>(storeToUpdate);
        }

        public async Task<Store> DeleteStore(string id)
        {
            var storeToDelete = await _collection.FindOneAndDeleteAsync(x => x.StoreId == id);
            Guard.Against.Null(storeToDelete, nameof(storeToDelete),
                                              $"No store found with ID '{id}'");
            return _mapper.Map<Store>(storeToDelete);
        }
    }
}
