using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }





        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products.ToListAsync();
            var productsDto = products.Select(x => x.ToProductDto());
            return Ok(productsDto);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return Ok(product.ToProductDto());
        }




        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto productDto)
        {

            var productModel = productDto.ToProductFromCreatedDto();
            await _context.Products.AddAsync(productModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, productModel.ToProductDto());
        }




        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }
            //if(User.IsInRole("Admin")){}
            productModel.Name = updateDto.Name;
            productModel.Price = updateDto.Price;
            productModel.Rating = updateDto.Rating;
            productModel.Description = updateDto.Description;
            productModel.CompanyName = updateDto.CompanyName;
            productModel.Active = updateDto.Active;
            //else{productModel.Rating = updateDto.Rating; }
            await _context.SaveChangesAsync();
            return Ok(productModel.ToProductDto());

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var productModel = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }
            _context.Products.Remove(productModel);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}