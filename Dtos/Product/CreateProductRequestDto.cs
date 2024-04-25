using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class CreateProductRequestDto
    {
        public string Name { get; set; } = string.Empty;

        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public string? Description { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        public bool Active { get; set; } = false;
    }
}