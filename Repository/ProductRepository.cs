using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }



        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> CreateProductAsync(Product productModel)
        {
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }
        public async Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto productDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null) return null;
            productModel.Name = productDto.Name;
            productModel.Price = productDto.Price;
            productModel.Rating = productDto.Rating;
            productModel.Description = productDto.Description;
            productModel.CompanyName = productDto.CompanyName;
            productModel.Active = productDto.Active;
            await _context.SaveChangesAsync();
            return productModel;

        }
        public async Task<Product?> DeleteProductAsync(int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null) return null;
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return productModel;
        }

    }
}