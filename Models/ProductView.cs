using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Models
{
    public class ProductView
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
        public string CategoryName { get; set; }
        public int CategoryCode { get; set; }
    }
}
