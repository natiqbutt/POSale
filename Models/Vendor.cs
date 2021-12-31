using System;
using System.Collections.Generic;

#nullable disable

namespace POSale.Models
{
    public partial class Vendor
    {
        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string VendorUsername { get; set; }
        public string VendorEmail { get; set; }
        public string VendorPassword { get; set; }
        public string VendorAddress { get; set; }
        public string VendorFeedback { get; set; }
        public DateTime VendorDateOfBirth { get; set; }

        public virtual Customer VendorNavigation { get; set; }
    }
}
