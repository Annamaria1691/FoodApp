using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Models;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<Category> CreateCategoryAsync(Category categoryModel);
        Task<Category?> UpdateCategoryAsync(int id, UpdateCategoryRequestDto categoryDto);
        Task<Category?> DeleteCategoryAsync(int id);
    }
}