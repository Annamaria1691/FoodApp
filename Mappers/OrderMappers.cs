using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Order;
using api.Dtos.OrderedProduct;
using api.Models;

namespace api.Mappers
{


    public static class OrderMappers
    {
        public static OrderDto ToOrderDto(this Order orderModel)
        {
            var orderDto = new OrderDto
            {
                Id = orderModel.Id,
                OrderRating = orderModel.OrderRating,
                DeliveryPrice = orderModel.DeliveryPrice,
                Total = orderModel.Total,
                OrderedOn = orderModel.OrderedOn,
                CustomerReview = orderModel.CustomerReview,
                Status = (api.Dtos.Order.OrderStatus)orderModel.Status,
                OrderedProducts = orderModel.OrderedProducts?.Select(op => op.ToOrderedProductDto()).ToList() ?? []

            };

            return orderDto;

        }

        public static Order ToOrderFromCreatedDto(this CreateOrderRequestDto orderDto)
        {
            return new Order
            {
                CustomerId = orderDto.CustomerId,
                DeliveryPrice = orderDto.DeliveryPrice,
                Total = orderDto.Total,
                OrderedOn = orderDto.OrderedOn
            };
        }

    }
}