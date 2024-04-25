using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Models;

namespace api.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task<Order?> GetOrderByIdAsync(int id);
        Task<Order> CreateOrderAsync(Order orderModel);
        Task<Order?> UpdateOrderAsync(int id, UpdateOrderRequestDto updateDto);
        Task<Order?> DeleteOrderAsync(int id);

    }
}