using System;
using System.Collections.Generic;

#nullable disable

namespace POSale.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryCode { get; set; }
        public string CategorySerial { get; set; }
        public int CategoryLevel { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
