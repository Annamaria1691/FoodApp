using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreateOrderAsync(Order orderModel)
        {
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return orderModel;
        }

        public async Task<Order?> DeleteOrderAsync(int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (orderModel == null) return null;
            _context.Remove(orderModel);
            return orderModel;
        }

        public async Task<List<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders.FindAsync(id);
        }

        public async Task<Order?> UpdateOrderAsync(int id, UpdateOrderRequestDto orderDto)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (orderModel == null) return null;
            orderModel.OrderRating = orderDto.OrderRating;
            orderModel.CustomerReview = orderDto.CustomerReview;
            //  orderModel.OrderedProducts = orderDto.OrderedProducts;
            await _context.SaveChangesAsync();
            return orderModel;
        }
    }
}