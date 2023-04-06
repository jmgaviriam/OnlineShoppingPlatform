using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users.Domain.DTO;
using Users.Domain.Entity;

namespace Users.UseCase.Gateway
{
    public interface IUserUseCase
    {
        Task<User> GetUserById(string id);
        Task<CreateUser> CreateUser(CreateUser user);
        Task<CreateUser> UpdateUser(UpdateUser user);
        Task<User> DeleteUser(string id);
    }
}
