using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class DB:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> Roles { get; set; }
        public DbSet<Items> items { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Billing> billings { get; set; }






    }
}