using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoInventory.Model
{
    public class ProductsIssue
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int Quantity { get; set; }     
        public List<ProductsIssueDetail> productsIssueDetail { get; set; }
    }
}
