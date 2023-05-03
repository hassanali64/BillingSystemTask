using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class User
    {
        
        public int? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
      
        public string Password { get; set; }


        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public UserRole Role { get; set; }

        public User()
        {
            RoleId = 1;
            //by default it will assign id 1 to the db table
        }
        public DbSet<Items> items { get; set; }
        public DbSet<Customers> customers { get; set; }
        public DbSet<Billing> Billings { get; set; }


    }
}