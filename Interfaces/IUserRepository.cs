using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUsersAsync();
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User userModel);
        Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto userDto);
        Task<User?> DeleteUserAsync(int id);
    }
}