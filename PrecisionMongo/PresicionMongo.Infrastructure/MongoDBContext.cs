using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;

namespace PrecisionMongo.Infrastructure
{
    public class MongoDBContext : IMongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IOptions<MongoDbSettingsEntity> options)
        {
            MongoClient _mongoClient = new MongoClient(options.Value.ConnectionString);
            _database = _mongoClient.GetDatabase(options.Value.DatabaseName);
        }
        public IMongoCollection<TodoEntity> Todos => _database.GetCollection<TodoEntity>("Todos");

    }
}
