using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.OrderedProduct;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderedProductController : ControllerBase
    {
        private readonly IOrderedProductRepository _orderedProductRepo;
        public OrderedProductController(IOrderedProductRepository orderedProductRepo)
        {
            _orderedProductRepo = orderedProductRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrderedProducts()
        {
            var orderedProducts = await _orderedProductRepo.GetAllOrderedProductsAsync();
            var orderedProductsDto = orderedProducts.Select(x => x.ToOrderedProductDto());
            return Ok(orderedProductsDto);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderedProductById([FromRoute] int id)
        {
            var orderedProduct = await _orderedProductRepo.GetOrderedProductByIdAsync(id);
            if (orderedProduct == null) return NotFound();
            return Ok(orderedProduct.ToOrderedProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderedProduct([FromBody] CreateOrderedProductRequestDto orderedProductDto)
        {

            var orderedProductModel = orderedProductDto.ToOrderedProductFromCreateDto();
            if (orderedProductDto.ProductId <= 0 || orderedProductDto.OrderId <= 0)
            {
                return BadRequest();
            }
            orderedProductModel.ProductId = orderedProductDto.ProductId;
            orderedProductModel.OrderId = orderedProductDto.OrderId;
            await _orderedProductRepo.CreateOrderedProductAsync(orderedProductModel);
            return CreatedAtAction(nameof(GetOrderedProductById), new { id = orderedProductModel.Id }, orderedProductModel.ToOrderedProductDto());

        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrderedProduct([FromRoute] int id, [FromBody] UpdateOrderedProductRequestDto updateDto)
        {
            var orderedProductModel = await _orderedProductRepo.UpdateOrderedProductAsync(id, updateDto);
            if (orderedProductModel == null) return NotFound();


            return Ok(orderedProductModel.ToOrderedProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrderedProduct([FromRoute] int id)
        {
            var orderedProductModel = await _orderedProductRepo.DeleteOrderedProductAsync(id);
            if (orderedProductModel == null) return NotFound();

            return NoContent();
        }


    }
}