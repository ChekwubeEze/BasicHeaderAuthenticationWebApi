using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Auth.Core.ModelsDto
{
    public class CreateUserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
