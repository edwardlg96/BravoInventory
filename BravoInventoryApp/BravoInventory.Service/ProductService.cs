using BravoInventory.Data.Infrastructure;
using BravoInventory.Model;

namespace BravoInventory.Service
{
    public interface IProductService : IRepository<Product>
    {
    }
    public class ProductService : Repository<Product>, IProductService
    {
        public ProductService(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}