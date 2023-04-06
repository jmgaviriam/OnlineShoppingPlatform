using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Users.Infrastructure.Entity;
using Users.Infrastructure.Interface;

namespace Users.Infrastructure
{
    public class Context : IContext
    {
        private readonly IMongoDatabase _database;

        public Context(string stringConnection, string DBname)
        {
            MongoClient client = new MongoClient(stringConnection);
            _database = client.GetDatabase(DBname);
        }

        public IMongoCollection<UserMongo> Users => _database.GetCollection<UserMongo>("Users");
    }
}
