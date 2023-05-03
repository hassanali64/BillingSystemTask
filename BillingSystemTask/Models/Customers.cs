using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BillingSystemTask.Models
{
    public class Customers
    {
        [Key]
        public int Id { get; set; }
        public string CustomerName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "RegistrationDate")]
        public DateTime? RegistrationDate { get; set; }
      

        public int UserId { get; set; }
        [ForeignKey("UserId")]

        public virtual User user { get; set; }

        public DbSet<Billing> billings { get; set; }
      



    }
}
