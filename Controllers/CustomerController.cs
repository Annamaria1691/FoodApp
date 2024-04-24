using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Customer;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            var customersDto = customers.Select(x => x.ToCustomerDto());
            return Ok(customersDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestDto customerDto)
        {
            var customerModel = customerDto.ToCustomerFromCreatedDto();
            await _context.Customers.AddAsync(customerModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerRequestDto updateDto)
        {
            var customerModel = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerModel == null) return NotFound();
            customerModel.Address = updateDto.Address;
            customerModel.PhoneNumber = updateDto.PhoneNumber;
            customerModel.Email = updateDto.Email;
            await _context.SaveChangesAsync();
            return Ok(customerModel.ToCustomerDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customerModel = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (customerModel == null) return NotFound();
            _context.Customers.Remove(customerModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}