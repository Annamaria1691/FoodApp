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
        public int? OrderId { get; set; }
        public Order? Order { get; set; }


        [Required]
        [Length(5, 25)]
        public string? Name { get; set; } = string.Empty;


        [Required]
        [Column(TypeName = "double(0.01,500)")]
        public double Price { get; set; }

        [MaxLength(200, ErrorMessage = "Maximum 200 characters")]
        public string? Description { get; set; } = string.Empty;
        public string? CompanyName { get; set; } = string.Empty;


    }
}