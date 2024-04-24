using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Order
{
    public class CreateOrderRequestDto
    {

        public decimal DeliveryPrice { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.Now;

    }
}