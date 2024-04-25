using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;

namespace api.Interfaces
{
    public interface ITotalCalculatorService
    {
        decimal CalculateTotal(List<OrderedProductDto> orderedProducts);
    }
}