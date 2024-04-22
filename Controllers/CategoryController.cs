using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            var categories = _context.Categories.ToList()
            .Select(x => x.ToCategoryDto());
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetCategoryById([FromRoute] int id)
        {

            var category = _context.Categories.Find(id);
            if (category == null) return NotFound();
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryRequestDto categoryDto)
        {
            var categoryModel = categoryDto.ToCategoryFromCreatedDto();
            _context.Categories.Add(categoryModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryModel.Id }, categoryModel.ToCategoryDto());

        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateDto)
        {
            var categoryModel = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryModel == null) return NotFound();
            categoryModel.Title = updateDto.Title;
            categoryModel.Active = updateDto.Active;
            categoryModel.Promoted = updateDto.Promoted;
            _context.SaveChanges();
            return Ok(categoryModel.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var categoryModel = _context.Categories.FirstOrDefault(x => x.Id == id);
            if (categoryModel == null) return NotFound();
            _context.Categories.Remove(categoryModel);
            _context.SaveChanges();
            return NoContent();
        }



    }
}