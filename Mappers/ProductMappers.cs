using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Models;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Name = productModel.Name,
                Rating = productModel.Rating,
                Price = productModel.Price,
                Description = productModel.Description,
                CompanyName = productModel.CompanyName
            };
        }



        public static Product ToProductFromCreatedDto(this CreateProductRequestDto productDto)
        {
            return new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                CompanyName = productDto.CompanyName,
                Active = productDto.Active
            };
        }
    }
}