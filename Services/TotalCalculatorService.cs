using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;
using api.Interfaces;

namespace api.Services
{
    public class TotalCalculatorService : ITotalCalculatorService
    {
        public decimal CalculateTotal(List<OrderedProductDto> orderedProducts)
        {
            decimal total = 0;
            if (orderedProducts == null)
            {
                return 0;
            }
            foreach (var product in orderedProducts)
            {
                total += product.Total;
            }
            return total;
        }
    }
}