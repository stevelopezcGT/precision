using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrecisionMongo.Core.DTOs
{
    public class ItemPaginationResponseDTO
    {
        public long TotalPages { get; set; }
        public object? ItemList { get; set; }
    }
}
