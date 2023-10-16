using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Infrastructure.Mappings
{
    public static class TodoToDto
    {
        public static TodoDTO CreateTodoDTO(TodoEntity entity)
        {
            return new TodoDTO
            {
                Duration = entity.Duration,
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}
