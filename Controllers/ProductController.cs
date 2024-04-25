using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Interfaces;
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

        private readonly IProductRepository _productRepo;
        public ProductController(IProductRepository productRepo)
        {
            _productRepo = productRepo;


        }





        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productRepo.GetAllProductsAsync();
            var productsDto = products.Select(x => x.ToProductDto());
            return Ok(productsDto);
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById([FromRoute] int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product.ToProductDto());
        }




        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequestDto productDto)
        {

            var productModel = productDto.ToProductFromCreatedDto();
            await _productRepo.CreateProductAsync(productModel);
            return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, productModel.ToProductDto());
        }




        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var productModel = await _productRepo.UpdateProductAsync(id, updateDto);
            if (productModel == null)
            {
                return NotFound();
            }

            return Ok(productModel.ToProductDto());

        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            var productModel = await _productRepo.DeleteProductAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }

            return NoContent();

        }


    }
}