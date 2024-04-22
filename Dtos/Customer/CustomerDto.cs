using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;

namespace api.Dtos.Customer
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [ForeignKey("User")]
        public int UserId { get; set; }
        public List<OrderDto> Orders { get; set; } = new List<OrderDto>();
    }
}