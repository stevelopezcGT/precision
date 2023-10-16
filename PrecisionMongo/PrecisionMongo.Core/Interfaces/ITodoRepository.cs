using PrecisionMongo.Core.Entities;

namespace PrecisionMongo.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoEntity>> GetAll();
    }
}
