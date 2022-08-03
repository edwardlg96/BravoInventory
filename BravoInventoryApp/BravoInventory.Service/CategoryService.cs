using BravoInventory.Data.Infrastructure;
using BravoInventory.Model;

namespace BravoInventory.Service
{
    public interface ICategoryService : IRepository<Category>
    {
        public bool CategoryExists(Model.DTO.CategoryDTO request);
        public Category SetRequestForAdd(Model.DTO.CategoryDTO request);
        public Category SetRequestForUpdate(Model.DTO.CategoryDTO request);
    }
    public class CategoryService : Repository<Category>, ICategoryService
    {
        //Consturctor
        public CategoryService(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        //Methods
        public bool CategoryExists(Model.DTO.CategoryDTO request)
        {
            if (Any(c => c.Code == request.Code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Category SetRequestForAdd(Model.DTO.CategoryDTO request)
        {
            try
            {
                Category category = new Category()
                {
                    Code = request.Code,
                    Name = request.Name,
                };

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }
        public Category SetRequestForUpdate(Model.DTO.CategoryDTO request)
        {
            try
            {
                Category category = Get(c => c.Code == request.Code);
                category.Code = request.Code;
                category.Name = request.Name;

                return category;
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

    }

}
