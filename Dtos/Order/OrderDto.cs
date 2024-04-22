using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;

namespace api.Dtos.Order
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled
    }

    public class OrderDto
    {
        public int Id { get; set; }

        public int? OrderRating { get; set; }


        public decimal DeliveryPrice { get; set; }

        public decimal Total { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.Now;
        public string? CustomerReview { get; set; } = string.Empty;

        public OrderStatus Status { get; set; }
        public List<OrderedProductDto>? OrderedProducts { get; set; }
    }
}