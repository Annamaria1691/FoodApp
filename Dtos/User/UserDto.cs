using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.User
{
    public class UserDto
    {
        public int Id { get; set; }

        public string FullName { get; set; } = String.Empty;

        public string Username { get; set; } = String.Empty;

        public string Password { get; set; } = string.Empty;

        public bool IsAdmin { get; set; } = false;
    }
}