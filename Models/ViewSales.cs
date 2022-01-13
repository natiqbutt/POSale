using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POSale.Models
{
    public class ViewSales
    {
        public Sale ObjSale { get; set; }
        public IList<SaleLine> ListSaleLine { get; set; }
    }
}
