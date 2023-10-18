using MongoDB.Bson.Serialization.Attributes;
using PrecisionMongo.Core.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Core.Entities
{
    public  class TodoEntity
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
        public DateTimeOffset SavedAt { get; set; } = DateTimeOffset.Now;
        public TodoStatus Status { get; set; } = TodoStatus.Pending;
    }
}
