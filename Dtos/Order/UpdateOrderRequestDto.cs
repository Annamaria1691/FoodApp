using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Order
{
    public class UpdateOrderRequestDto
    {
        public int? OrderRating { get; set; }
        public string? CustomerReview { get; set; } = string.Empty;
        public List<api.Models.OrderedProduct>? OrderedProducts { get; set; }
    }
}