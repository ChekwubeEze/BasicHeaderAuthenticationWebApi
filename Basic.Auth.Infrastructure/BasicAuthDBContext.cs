using Basic.Auth.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basic.Auth.Infrastructure
{
    public class BasicAuthDBContext: DbContext
    {
        public BasicAuthDBContext(DbContextOptions<BasicAuthDBContext> options)
            :base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Role> Roles { get; set; }

    }
}
