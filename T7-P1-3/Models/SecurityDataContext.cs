using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace T7_P1_3.Models
{
    public class SecurityDataContext : DbContext
    {
        public SecurityDataContext() : base("SecirityExampleConnection")
        {
            Database.SetInitializer<SecurityDataContext>(new InitializeWithDefaultUsers());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}