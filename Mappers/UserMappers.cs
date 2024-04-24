using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;
using Microsoft.EntityFrameworkCore.Storage;

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

        public static User ToUserFromCreatedDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                FullName = userDto.FullName,
                Username = userDto.Username,
                Password = userDto.Password,
                IsAdmin = userDto.IsAdmin
            };
        }
    }
}