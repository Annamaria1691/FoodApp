using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.OrderedProduct;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderedProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderedProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderedProducts()
        {
            var orderedProducts = await _context.OrderedProducts.ToListAsync();
            var orderedProductsDto = orderedProducts.Select(x => x.ToOrderedProductDto());
            return Ok(orderedProductsDto);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderedProductById([FromRoute] int id)
        {
            var orderedProduct = await _context.OrderedProducts.FindAsync(id);
            if (orderedProduct == null) return NotFound();
            return Ok(orderedProduct.ToOrderedProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderedProduct([FromBody] CreateOrderedProductRequestDto orderedProductDto)
        {
            var orderedProductModel = orderedProductDto.ToOrderedProductFromCreateDto();
            await _context.OrderedProducts.AddAsync(orderedProductModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderedProductById), new { id = orderedProductModel.Id }, orderedProductModel.ToOrderedProductDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrderedProduct([FromRoute] int id, [FromBody] UpdateOrderedProductRequestDto updateDto)
        {
            var orderedProductModel = await _context.OrderedProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (orderedProductModel == null) return NotFound();
            orderedProductModel.Specifications = updateDto.Specifications;
            orderedProductModel.Quantity = updateDto.Quantity;
            orderedProductModel.Total = updateDto.Total;
            await _context.SaveChangesAsync();
            return Ok(orderedProductModel.ToOrderedProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderedProduct([FromRoute] int id)
        {
            var orderedProductModel = await _context.OrderedProducts.FirstOrDefaultAsync(x => x.Id == id);
            if (orderedProductModel == null) return NotFound();
            _context.OrderedProducts.Remove(orderedProductModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}