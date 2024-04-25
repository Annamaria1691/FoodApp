using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product?> GetProductByIdAsync(int id);
        Task<Product> CreateProductAsync(Product productModel);
        Task<Product?> UpdateProductAsync(int id, UpdateProductRequestDto productDto);
        Task<Product?> DeleteProductAsync(int id);
    }
}