using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderedProductRepository
    {
        Task<List<OrderedProduct>> GetAllOrderedProductsAsync();
        Task<OrderedProduct?> GetOrderedProductByIdAsync(int id);
        Task<OrderedProduct> CreateOrderedProductAsync(OrderedProduct orderedProductModel);
        Task<OrderedProduct?> UpdateOrderedProductAsync(int id, UpdateOrderedProductRequestDto orderedProductDto);
        Task<OrderedProduct?> DeleteOrderedProductAsync(int id);
    }
}