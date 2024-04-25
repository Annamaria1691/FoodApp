using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Product
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Rating { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }

        public string? Description { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;


    }
}