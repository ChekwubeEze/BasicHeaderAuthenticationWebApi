﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Auth.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

    }
}
