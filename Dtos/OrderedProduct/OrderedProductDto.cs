using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.OrderedProduct
{
    public class OrderedProductDto
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }
        public string? Specifications { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}