using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                FullName = userModel.FullName,
                Username = userModel.Username,
                Password = userModel.Password,
                IsAdmin = userModel.IsAdmin
            };
        }
    }
}