using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;

namespace PrecisionMongo.API.Controllers
{
    /// <summary>
    /// Todo controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;
        private readonly IOutputCacheStore cache;

        public TodoController(ITodoService todoService, IOutputCacheStore cache)
        {
            this.todoService = todoService;
            this.cache=cache;
        }

        /// <summary>
        /// Get All Todo items
        /// </summary>
        /// <returns>Todo's list</returns>
        [HttpGet]
        [OutputCache(PolicyName = "todoCachePolicy")]
        public async Task<List<TodoDTO>> GetAll()
        {
            return await todoService.GetAll();
        }

        /// <summary>
        /// Get Todo items with pagination
        /// </summary>
        /// <param name="pageSize">Size for every page returned</param>
        /// <param name="pageNumber">Page number</param>
        /// <returns>A Todo's list with into an instance of <see cref="ItemPaginationResponseDTO"/></returns>
        [HttpGet("WithPagination")]
        [OutputCache(PolicyName = "todoCachePolicy", VaryByQueryKeys = new[] {"pageSize", "pageNumber"})]
        public async Task<ItemPaginationResponseDTO> GetAllWithPagination(int pageSize, int pageNumber)
        {
            return await todoService.GetAll(pageSize, pageNumber);
        }

        /// <summary>
        /// Update Todo item
        /// </summary>
        /// <param name="id">Id for item to update</param>
        /// <param name="todoDTO">Todo instance to update</param>
        /// <returns>No returns</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PutTodoDTO(string id, TodoDTO todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            await todoService.UpdateAsync(id, todoDTO);
            await cache.EvictByTagAsync("tag-todo", default);

            return Ok();
        }

        /// <summary>
        /// Create Todo item
        /// </summary>
        /// <param name="todoCreateDTO">Todo instance to be created</param>
        /// <returns>No returns</returns>
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<bool>> PostTodoCreateDTO(TodoCreateDTO todoCreateDTO)
        {
            await todoService.CreateAsync(todoCreateDTO);
            await cache.EvictByTagAsync("tag-todo", default);
            return Ok();
        }

        /// <summary>
        /// Delete Todo item
        /// </summary>
        /// <param name="id">Todo Id to be deleted</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            await todoService.RemoveAsync(id);
            await cache.EvictByTagAsync("tag-todo", default);
            return Ok();
        }

        /// <summary>
        /// Get a Todo item
        /// </summary>
        /// <param name="id">Todo Id to get from</param>
        /// <returns>A Todo item</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [OutputCache(PolicyName = "todoCachePolicy", VaryByQueryKeys = new[] { "id" })]
        public async Task<TodoDTO?> GetTodo(string id)
        {
            return await todoService.GetAsync(id);
        }

    }
}
