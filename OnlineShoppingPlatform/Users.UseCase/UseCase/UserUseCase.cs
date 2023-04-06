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
    public class UserUseCase : IUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public UserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            return await _userRepository.CreateUser(user);
        }

        public async Task<CreateUser> UpdateUser(UpdateUser user)
        {
            return await _userRepository.UpdateUser(user);
        }

        public async Task<User> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
