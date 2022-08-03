using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoInventory.Model.DTO
{
    public class ProductDTO
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string CategoryCode { get; set; }
    }
}
