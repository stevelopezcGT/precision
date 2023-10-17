using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        /// <summary>
        /// Get All Todo items
        /// </summary>
        /// <returns>Todo's list</returns>
        [HttpGet]
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

            return Ok();
        }

    }
}
