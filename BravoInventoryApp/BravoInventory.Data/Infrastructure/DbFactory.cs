using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BravoInventory.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        InventoryDbContext Init();
    }
    public class DbFactory : IDbFactory
    {
        private InventoryDbContext _inventoryDbContext;
        private readonly DbContextOptions<InventoryDbContext> _options;
        public DbFactory(IConfiguration configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<InventoryDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("InventoryDb"));
            var options = optionsBuilder.Options;
            _options = options;
        }
        public void Dispose()
        {
            _inventoryDbContext?.Dispose();
        }

        public InventoryDbContext Init()
        {
            return _inventoryDbContext ?? (_inventoryDbContext = new InventoryDbContext(_options));
        }
    }
}