using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        
        public string ItemName { get; set; }
        
        public string Description { get; set; }
        public int fee { get; set; }
      
        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User user { get; set; }

        public DbSet<Billing> billings { get; set; }






    }
}