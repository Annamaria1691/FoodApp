using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Customer;
using api.Interfaces;
using api.Mappers;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository _customerRepo;
        private readonly ApplicationDbContext _context;
        public CustomerController(ICustomerRepository customerRepo, ApplicationDbContext context)
        {


            _customerRepo = customerRepo;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepo.GetAllCustomersAsync();
            var customersDto = customers.Select(x => x.ToCustomerDto());
            return Ok(customersDto);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById([FromRoute] int id)
        {
            var customer = await _customerRepo.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequestDto customerDto)
        {

            var userRepository = new UserRepository(_context);
            var user = await userRepository.GetUserByIdAsync(customerDto.UserId);
            if (user == null)
            {
                return NotFound("User not found");
            }
            var customerModel = customerDto.ToCustomerFromCreatedDto();
            customerModel.UserId = user.Id;
            await _customerRepo.CreateCustomerAsync(customerModel);
            return CreatedAtAction(nameof(GetCustomerById), new { id = customerModel.Id }, customerModel.ToCustomerDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCustomer([FromRoute] int id, [FromBody] UpdateCustomerRequestDto updateDto)
        {
            var customerModel = await _customerRepo.UpdateCustomerAsync(id, updateDto);
            if (customerModel == null) return NotFound();

            return Ok(customerModel.ToCustomerDto());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customerModel = await _customerRepo.DeleteCustomerAsync(id);
            if (customerModel == null) return NotFound();

            return NoContent();
        }
    }
}