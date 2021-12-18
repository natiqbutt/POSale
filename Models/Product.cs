using System;
using System.Collections.Generic;

#nullable disable

namespace POSale.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public int ProductCode { get; set; }
        public string ProductSerial { get; set; }
        public int ProductQuantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
