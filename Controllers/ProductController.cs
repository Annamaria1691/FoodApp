using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAllProducts()
        {
            var products = _context.Products.ToList()
            .Select(x => x.ToProductDto());
            return Ok(products);
        }



        [HttpGet("{id}")]
        public IActionResult GetProductById([FromRoute] int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) return NotFound();
            return Ok(product.ToProductDto());
        }




        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductRequestDto productDto)
        {

            var productModel = productDto.ToProductFromCreatedDto();
            _context.Products.Add(productModel);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProductById), new { id = productModel.Id }, productModel.ToProductDto());
        }




        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] UpdateProductRequestDto updateDto)
        {
            var productModel = _context.Products.FirstOrDefault(x => x.Id == id);
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
            _context.SaveChanges();
            return Ok(productModel.ToProductDto());

        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
            var productModel = _context.Products.FirstOrDefault(x => x.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }
            _context.Products.Remove(productModel);
            _context.SaveChanges();
            return NoContent();

        }


    }
}