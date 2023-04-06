using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Users.Infrastructure.Entity;

namespace Users.Infrastructure.Interface
{
    public interface IContext
    {
        public IMongoCollection<UserMongo> Users { get; }
    }
}
