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
        public string Desciption { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string CategoryCode { get; set; }
    }
}
