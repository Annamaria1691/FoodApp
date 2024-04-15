using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Order
    {

        public int Id { get; set; }
        public List<Product> Products = new List<Product>();

    }
}