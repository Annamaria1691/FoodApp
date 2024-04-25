using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.OrderedProduct
{
    public class CreateOrderedProductRequestDto
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string? Specifications { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal Total { get; set; }
    }
}