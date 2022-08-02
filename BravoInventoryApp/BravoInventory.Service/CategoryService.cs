using BravoInventory.Data.Infrastructure;
using BravoInventory.Model;

namespace BravoInventory.Service
{
    public interface ICategoryService : IRepository<Category>
    {
    }
    public class CategoryService : Repository<Category>, ICategoryService
    {
        public CategoryService(IDbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}