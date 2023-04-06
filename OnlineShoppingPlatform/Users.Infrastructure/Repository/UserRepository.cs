using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using Users.Domain.DTO;
using Users.Domain.Entity;
using Users.Infrastructure.Entity;
using Users.Infrastructure.Interface;
using Users.UseCase.Gateway.Repository;

namespace Users.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoCollection<UserMongo> _collection;
        private readonly IMapper _mapper;

        public UserRepository(IContext context, IMapper mapper)
        {
            _collection = context.Users;
            _mapper = mapper;
        }


        public async Task<User> GetUserById(string id)
        {
            var user = await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
            Guard.Against.Null(user, nameof(user), $"No se encontró ningún entrenador con el ID '{id}'");
            return _mapper.Map<User>(user);
        }

        public async Task<CreateUser> CreateUser(CreateUser user)
        {
            var userToCreate = _mapper.Map<UserMongo>(user);
            await _collection.InsertOneAsync(userToCreate);
            return user;
        }

        public async Task<CreateUser> UpdateUser(UpdateUser user)
        {
            var userToUpdate = _mapper.Map<UserMongo>(user);
            var userUpdated = await _collection.FindOneAndReplaceAsync(x => x.Id == user.Id, userToUpdate);
            Guard.Against.Null(userUpdated, nameof(userUpdated),
                $"No se encontró ningún entrenador con el ID '{user.Id}'");
            return _mapper.Map<CreateUser>(userToUpdate);
        }

        public async Task<User> DeleteUser(string id)
        {
            var userToDelete = await _collection.FindOneAndDeleteAsync(x => x.Id == id);
            Guard.Against.Null(userToDelete, nameof(userToDelete),
                               $"No se encontró ningún entrenador con el ID '{id}'");
            return _mapper.Map<User>(userToDelete);
        }
    }
}
