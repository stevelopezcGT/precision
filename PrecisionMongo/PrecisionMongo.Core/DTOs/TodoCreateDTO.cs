using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Core.DTOs
{
    public class TodoCreateDTO
    {
        public string Name { get; set; } = string.Empty;
        public int Duration { get; set; }
    }
}
