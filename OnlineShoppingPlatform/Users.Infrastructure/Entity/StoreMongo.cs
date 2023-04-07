using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Users.Infrastructure.Entity
{
    public class StoreMongo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string StoreId { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Logo { get; set; }
        public bool IsDeleted { get; set; }
    }
}
