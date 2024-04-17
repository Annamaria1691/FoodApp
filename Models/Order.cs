using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Canceled
    }
    public class Order
    {

        public int Id { get; set; }

        public int? OrderRating { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal DeliveryPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
        public DateTime OrderedOn { get; set; } = DateTime.Now;
        public string? CustomerReview { get; set; } = string.Empty;

        public OrderStatus Status { get; set; }
        public List<OrderedProduct> OrderedProducts { get; set; }



    }
}