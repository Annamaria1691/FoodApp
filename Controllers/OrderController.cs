using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Order;
using api.Interfaces;
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
        private readonly IOrderRepository _orderRepo;
        private readonly ITotalCalculatorService _totalCalculator;
        public OrderController(IOrderRepository orderRepo, ITotalCalculatorService totalCalculator)
        {
            _orderRepo = orderRepo;
            _totalCalculator = totalCalculator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderRepo.GetAllOrdersAsync();
            var ordersDto = orders.Select(x => x.ToOrderDto());
            return Ok(ordersDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById([FromRoute] int id)
        {
            var order = await _orderRepo.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order.ToOrderDto());

        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto orderDto)
        {
            var orderModel = orderDto.ToOrderFromCreatedDto();
            if (orderModel.OrderedProducts != null)
            {
                var orderedProductsDto = orderModel.OrderedProducts.Select(op => op.ToOrderedProductDto()).ToList();
                orderModel.Total = _totalCalculator.CalculateTotal(orderedProductsDto);
            }
            else
            {
                orderModel.Total = 0;
            }
            await _orderRepo.CreateOrderAsync(orderModel);
            return CreatedAtAction(nameof(GetOrderById), new { id = orderModel.Id }, orderModel.ToOrderDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateOrder([FromRoute] int id, [FromBody] UpdateOrderRequestDto updateDto)
        {
            var orderModel = await _orderRepo.UpdateOrderAsync(id, updateDto);
            if (orderModel == null) return NotFound();
            return Ok(orderModel.ToOrderDto());

        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteOrder([FromRoute] int id)
        {
            var orderModel = await _orderRepo.DeleteOrderAsync(id);
            if (orderModel == null) return NotFound();
            return NoContent();
        }

    }
}