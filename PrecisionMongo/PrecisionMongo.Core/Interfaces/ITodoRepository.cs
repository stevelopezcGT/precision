using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;

namespace PrecisionMongo.Core.Interfaces
{
    public interface ITodoRepository
    {
        Task<List<TodoDTO>> GetAll();

        Task<TodoDTO?> GetAsync(string id) ;

        Task CreateAsync(TodoCreateDTO newTodo) ;

        Task UpdateAsync(string id, TodoDTO updateTodo);

        Task RemoveAsync(string id) ;

        Task<ItemPaginationResponseDTO> GetAll(int pageSize, int pageNumber);
    }
}
