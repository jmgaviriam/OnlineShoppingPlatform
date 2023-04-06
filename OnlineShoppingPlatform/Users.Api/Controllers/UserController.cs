using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.UseCase.Gateway;

namespace Users.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserUseCase _userUseCase;
        private readonly IMapper _mapper;

        public UserController(IUserUseCase userUseCase, IMapper mapper)
        {
            _userUseCase = userUseCase;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<User> GetUserById(string id)
        {
            return await _userUseCase.GetUserById(id);
        }

        [HttpPost]
        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            return await _userUseCase.CreateUser(user);
        }

        [HttpPut]
        public async Task<CreateUser> UpdateUser(UpdateUser user)
        {
            return await _userUseCase.UpdateUser(user);
        }

        [HttpDelete]
        public async Task<User> DeleteUser(string id)
        {
            return await _userUseCase.DeleteUser(id);
        }

    }
}
