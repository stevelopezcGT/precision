using MongoDB.Driver;
using PrecisionMongo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Core.Interfaces
{
    public interface IMongoDBContext
    {
        IMongoCollection<TodoEntity> Todos {  get; }
    }
}
