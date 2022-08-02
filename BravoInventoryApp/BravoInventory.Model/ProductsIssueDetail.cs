using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravoInventory.Model
{
    public class ProductsIssueDetail
    {
        public int Id { get; set; }
        public int ProductsIssueId { get; set; }
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription{ get; set; }
        public string CategoryId { get; set; }
        public string CategoryCode { get; set; }
        public int Quantity { get; set; }
    }
}
