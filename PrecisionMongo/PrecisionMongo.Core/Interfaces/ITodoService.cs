using PrecisionMongo.Core.Entities;

namespace PrecisionMongo.Core.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoEntity>> GetAll();
    }
}
