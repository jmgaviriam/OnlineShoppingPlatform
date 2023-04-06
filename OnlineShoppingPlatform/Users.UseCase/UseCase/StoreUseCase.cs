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
    public class StoreUseCase : IStoreUseCase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreUseCase(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<Store> GetStoreById(string id)
        {
            return await _storeRepository.GetStoreById(id);
        }

        public async Task<CreateStore> CreateStore(CreateStore store)
        {
            return await _storeRepository.CreateStore(store);
        }

        public async Task<CreateStore> UpdateStore(UpdateStore store)
        {
            return await _storeRepository.UpdateStore(store);
        }

        public async Task<Store> DeleteStore(string id)
        {
            return await _storeRepository.DeleteStore(id);
        }
    }
}
