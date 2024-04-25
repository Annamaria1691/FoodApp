using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Models;

namespace api.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomersAsync();
        Task<Customer?> GetCustomerByIdAsync(int id);
        Task<Customer> CreateCustomerAsync(Customer customerModel);
        Task<Customer?> UpdateCustomerAsync(int id, UpdateCustomerRequestDto customerDto);
        Task<Customer?> DeleteCustomerAsync(int id);
    }
}