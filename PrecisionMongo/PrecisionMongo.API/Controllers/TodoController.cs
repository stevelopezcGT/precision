using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;

namespace PrecisionMongo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService todoService;

        public TodoController(ITodoService todoService)
        {
            this.todoService = todoService;
        }

        [HttpGet]

        public async Task<List<TodoDTO>> GetAll()
        {
            return await todoService.GetAll();
        }

        [HttpGet("WithPagination")]

        public async Task<ItemPaginationResponseDTO> GetAllWithPagination(int pageSize, int pageNumber)
        {
            return await todoService.GetAll(pageSize, pageNumber);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoDTO(string id, TodoDTO todoDTO)
        {
            if (id != todoDTO.Id)
            {
                return BadRequest();
            }

            await todoService.UpdateAsync(id, todoDTO);

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<bool>> PostTodoCreateDTO(TodoCreateDTO todoCreateDTO)
        {
            await todoService.CreateAsync(todoCreateDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(string id)
        {
            await todoService.RemoveAsync(id);

            return NoContent();
        }

    }
}
