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

        public Task<List<TodoEntity>> GetAll()
        {
            return todoRepository.GetAll();
        }
    }
}
