using BravoInventory.Model;
using Microsoft.EntityFrameworkCore;

namespace BravoInventory.Data
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options) : base(options){ }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductEntry> ProductEntries { get; set; }
    }
}

