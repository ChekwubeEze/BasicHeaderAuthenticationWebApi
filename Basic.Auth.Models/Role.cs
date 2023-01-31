﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Auth.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int userId { get; set; }
        public User User { get; set; }
    }
}
