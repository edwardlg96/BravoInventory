using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BravoInventory.Model
{
    public class Category
    {
        //public Category()
        //{
        //    Products = new HashSet<Product>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        //public virtual ICollection<Product> Products { get; set; }
    }
}