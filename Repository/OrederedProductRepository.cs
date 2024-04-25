using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.OrderedProduct;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class OrederedProductRepository : IOrderedProductRepository
    {
        private readonly ApplicationDbContext _context;

        public OrederedProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<OrderedProduct> CreateOrderedProductAsync(OrderedProduct orderedProductModel)
        {
            await _context.OrderedProducts.AddAsync(orderedProductModel);
            await _context.SaveChangesAsync();
            return orderedProductModel;
        }

        public async Task<OrderedProduct?> DeleteOrderedProductAsync(int id)
        {
            var orderedProductModel = await _context.OrderedProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (orderedProductModel == null) return null;
            _context.OrderedProducts.Remove(orderedProductModel);
            await _context.SaveChangesAsync();
            return orderedProductModel;
        }

        public async Task<List<OrderedProduct>> GetAllOrderedProductsAsync()
        {
            return await _context.OrderedProducts.ToListAsync();
        }

        public async Task<OrderedProduct?> GetOrderedProductByIdAsync(int id)
        {
            return await _context.OrderedProducts.FindAsync(id);
        }

        public async Task<OrderedProduct?> UpdateOrderedProductAsync(int id, CreateOrderedProductRequestDto orderedProductDto)
        {
            var orderedProductModel = await _context.OrderedProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (orderedProductModel == null) return null;
            orderedProductModel.ProductId = orderedProductDto.ProductId;
            orderedProductModel.Specifications = orderedProductDto.Specifications;
            orderedProductModel.Quantity = orderedProductDto.Quantity;
            orderedProductModel.Total = orderedProductDto.Total;
            await _context.SaveChangesAsync();
            return orderedProductModel;
        }

        public Task<OrderedProduct?> UpdateOrderedProductAsync(int id, UpdateOrderedProductRequestDto orderedProductDto)
        {
            throw new NotImplementedException();
        }
    }
}