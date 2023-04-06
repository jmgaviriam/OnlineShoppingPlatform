using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.DTO;
using Users.Domain.Entity;

namespace Users.UseCase.Gateway.Repository
{
    public interface IStoreRepository
    {
        Task<Store> GetStoreById(string id);
        Task<CreateStore> CreateStore(CreateStore store);
        Task<CreateStore> UpdateStore(UpdateStore store);
        Task<Store> DeleteStore(string id);
    }
}
