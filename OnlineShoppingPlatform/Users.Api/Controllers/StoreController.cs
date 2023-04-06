using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway.Repository;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<Store> GetStoreById(string id)
        {
            return await _storeRepository.GetStoreById(id);
        }

        [HttpPost]
        public async Task<CreateStore> CreateStore(CreateStore store)
        {
            return await _storeRepository.CreateStore(store);
        }

        [HttpPut]
        public async Task<CreateStore> UpdateStore(UpdateStore store)
        {
            return await _storeRepository.UpdateStore(store);
        }

        [HttpDelete]
        public async Task<Store> DeleteStore(string id)
        {
            return await _storeRepository.DeleteStore(id);
        }
    }
}
