using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Customer;
using api.Models;

namespace api.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDto ToCustomerDto(this Customer customerModel)
        {
            var customerDto = new CustomerDto
            {
                Id = customerModel.Id,
                Address = customerModel.Address,
                PhoneNumber = customerModel.PhoneNumber,
                Email = customerModel.Email,
                UserId = customerModel.UserId,
                Orders = customerModel.Orders.Select(o => o.ToOrderDto()).ToList()
            };
            return customerDto;
        }



        public static Customer ToCustomerFromCreatedDto(this CreateCustomerRequestDto customerDto)
        {
            return new Customer
            {
                Address = customerDto.Address,
                PhoneNumber = customerDto.PhoneNumber,
                Email = customerDto.Email

            };
        }
    }
}