using PrecisionMongo.Core.Entities;

namespace PrecisionMongo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoEntity>> GetAll();

        Task<TodoEntity?> GetAsync(string id);

        Task CreateAsync(TodoEntity newTodo);

        Task UpdateAsync(string id, TodoEntity updateTodo);

        Task RemoveAsync(string id);
    }
}
