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

        public async Task<TodoEntity?> GetAsync(string id) => await context.Todos.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(TodoEntity newTodo) => await context.Todos.InsertOneAsync(newTodo);

        public async Task UpdateAsync(string id, TodoEntity updateTodo) => await context.Todos.ReplaceOneAsync(x => x.Id == id, updateTodo);

        public async Task RemoveAsync(string id) => await context.Todos.DeleteOneAsync(x => x.Id == id);

    }
}
