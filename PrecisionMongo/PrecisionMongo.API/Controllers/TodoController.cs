using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<List<TodoEntity>> GetAll()
        {
            return await todoService.GetAll();
        }
    }
}
