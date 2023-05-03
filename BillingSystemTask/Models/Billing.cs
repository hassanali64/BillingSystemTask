using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BillingSystemTask.Models
{
    public class Billing
    {
        public int BillingId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customers customers { get; set; }
        public int ItemId { get; set; }
        public virtual Items items { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalCost { get; set; }
    }

}