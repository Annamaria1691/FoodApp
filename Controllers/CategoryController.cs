using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {

            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepo.GetAllCategoriesAsync();
            var categoriesDto = categories.Select(x => x.ToCategoryDto());
            return Ok(categoriesDto);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] int id)
        {

            var category = await _categoryRepo.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreatedDto();
            await _categoryRepo.CreateCategoryAsync(categoryModel);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            var categoryModel = await _categoryRepo.UpdateCategoryAsync(id, updateDto);
            if (categoryModel == null) return NotFound();

            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var categoryModel = await _categoryRepo.DeleteCategoryAsync(id);
            if (categoryModel == null) return NotFound();

            return NoContent();
        }



    }
}