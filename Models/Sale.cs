using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Models
{
    public class Sale
    {
        public int Id { get; set; }
        public int Serial { get; set; }
        public string Code { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
