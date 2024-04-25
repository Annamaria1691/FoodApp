using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;

namespace api.Dtos.Order
{
    public class CreateOrderRequestDto
    {
        public int CustomerId { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.Now;



    }
}