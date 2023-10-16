using MongoDB.Driver;
using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly IMongoDBContext context;

        public TodoRepository(IMongoDBContext context)
        {
            this.context=context;
        }

        public async Task<List<TodoEntity>> GetAll() => await context.Todos.Find(_ => true).ToListAsync();
        
    }
}
