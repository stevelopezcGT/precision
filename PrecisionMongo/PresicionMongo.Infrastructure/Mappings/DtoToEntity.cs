using PrecisionMongo.Core.DTOs;
using PrecisionMongo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Infrastructure.Mappings
{
    public class DtoToEntity
    {
        public static TodoEntity CreateTodo(TodoCreateDTO entity)
        {
            return new TodoEntity
            {
                Duration = entity.Duration,
                Name = entity.Name,
            };
        }

        public static TodoEntity CreateTodo(TodoDTO entity)
        {
            return new TodoEntity
            {
                Duration = entity.Duration,
                Name = entity.Name,
                Id = entity.Id,
                Status = entity.Status
            };
        }
    }
}
