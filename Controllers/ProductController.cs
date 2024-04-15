using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;

        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_context.Products.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            if (id <= 0) return BadRequest();
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return Ok(product);

        }


        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            return Ok("new product");
        }


        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            return Ok($"Product with id{id} to update");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            return Ok($"Delete product with id{id}");
        }


    }
}