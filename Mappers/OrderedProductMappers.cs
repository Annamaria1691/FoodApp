using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.OrderedProduct;
using api.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace api.Mappers
{
    public static class OrderedProductMappers
    {
        public static OrderedProductDto ToOrderedProductDto(this OrderedProduct orderedProductModel)
        {
            return new OrderedProductDto
            {
                Id = orderedProductModel.Id,
                ProductId = orderedProductModel.ProductId,
                OrderId = orderedProductModel.OrderId,
                Specifications = orderedProductModel.Specifications,
                Quantity = orderedProductModel.Quantity,
                Total = orderedProductModel.Total

            };
        }

        public static OrderedProduct ToOrderedProductFromCreateDto(this CreateOrderedProductRequestDto orderedProductDto)
        {
            return new OrderedProduct
            {
                Specifications = orderedProductDto.Specifications,
                Quantity = orderedProductDto.Quantity,
                Total = orderedProductDto.Total
            };
        }
    }
}