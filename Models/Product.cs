using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? Rating { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public string? Description { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public bool Active { get; set; } = false;


    }
}