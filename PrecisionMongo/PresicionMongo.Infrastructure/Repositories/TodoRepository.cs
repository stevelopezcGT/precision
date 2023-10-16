using MongoDB.Driver;
using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;
using PrecisionMongo.Infrastructure.Mappings;
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

        public async Task<List<TodoDTO>> GetAll()
        {
            List<TodoDTO> listTodos = new List<TodoDTO>();
            var todos = (await context.Todos.Find(_ => true).ToListAsync());
            todos.ForEach(d => listTodos.Add(TodoToDto.CreateTodoDTO(d)));
            return listTodos;
        }


        public async Task<TodoDTO?> GetAsync(string id)
        {
            var todo =await context.Todos.Find(x => x.Id == id).FirstOrDefaultAsync();
            return TodoToDto.CreateTodoDTO(todo);
        }

        public async Task CreateAsync(TodoCreateDTO newTodo)
        {
            var todo = DtoToEntity.CreateTodo(newTodo);
            await context.Todos.InsertOneAsync(todo);
        }

        public async Task UpdateAsync(string id, TodoDTO updateTodo)
        {
            var todo = DtoToEntity.CreateTodo(updateTodo);
            await context.Todos.ReplaceOneAsync(x => x.Id == id, todo);
        }

        public async Task RemoveAsync(string id) => await context.Todos.DeleteOneAsync(x => x.Id == id);

    }
}
