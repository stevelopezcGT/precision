using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;

namespace PrecisionMongo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoDTO>> GetAll();

        Task<TodoDTO?> GetAsync(string id);

        Task CreateAsync(TodoCreateDTO newTodo);

        Task UpdateAsync(string id, TodoDTO todoItem);

        Task RemoveAsync(string id);
    }
}
