using System;
using System.Collections.Generic;

#nullable disable

namespace POSale.Models
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerPassword { get; set; }
        public string CustomerFeedback { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }
        public DateTime CustomerDateOfBirth { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
