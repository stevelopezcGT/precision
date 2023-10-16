using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Core.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            this.todoRepository=todoRepository;
        }

        public async Task CreateAsync(TodoEntity newTodo)
        {
            await todoRepository.CreateAsync(newTodo);
        }

        public async Task<List<TodoEntity>> GetAll()
        {
            return await todoRepository.GetAll();
        }

        public async Task<TodoEntity?> GetAsync(string id)
        {
            return await todoRepository.GetAsync(id);
        }

        public async Task RemoveAsync(string id)
        {
            await todoRepository.RemoveAsync(id);
        }

        public async Task UpdateAsync(string id, TodoEntity updateTodo)
        {
            await todoRepository.UpdateAsync(id, updateTodo);
        }
    }
}
