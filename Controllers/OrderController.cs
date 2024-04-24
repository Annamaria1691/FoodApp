using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders.ToListAsync();
            var ordersDto = orders.Select(x => x.ToOrderDto());
            return Ok(ordersDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null) return NotFound();
            return Ok(order.ToOrderDto());

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromCreatedDto();
            await _context.Orders.AddAsync(orderModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetOrderById), new { id = orderModel.Id }, orderModel.ToOrderDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderRequestDto updateDto)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (orderModel == null) return NotFound();
            orderModel.OrderRating = updateDto.OrderRating;
            orderModel.CustomerReview = updateDto.CustomerReview;
            orderModel.OrderedProducts = updateDto.OrderedProducts;
            await _context.SaveChangesAsync();
            return Ok(orderModel.ToOrderDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var orderModel = await _context.Orders.FirstOrDefaultAsync(x => x.Id == id);
            if (orderModel == null) return NotFound();
            _context.Orders.Remove(orderModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }

    }
}