using BravoInventory.Data.Infrastructure;
using BravoInventory.Model;

namespace BravoInventory.Service
{
    public interface IProductService : IRepository<Product>
    {
        public bool ProductExists(Model.DTO.ProductDTO request);
        public Product SetRequestForAdd(Model.DTO.ProductDTO request, Category category);
        public Product SetRequestForUpdate(Model.DTO.ProductDTO request, Category category);
    }
    public class ProductService : Repository<Product>, IProductService
    {
        //Consturctor
        public ProductService(IDbFactory dbFactory) : base(dbFactory)
        {

        }

        //Methods
        public bool ProductExists(Model.DTO.ProductDTO request)
        {
            if (Any(p => p.Code == request.Code))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Product SetRequestForAdd(Model.DTO.ProductDTO request, Category category)
        {
            try
            {
                Product product = new Product()
                {
                    Code = request.Code,
                    Description = request.Desciption,
                    Price = request.Price,
                    Stock = request.Stock,
                    CategoryId = category.Id
                };

                return product;

            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }
        public Product SetRequestForUpdate(Model.DTO.ProductDTO request, Category category)
        {
            try
            {
                Product product = Get(p => p.Code == request.Code);
                product.Code = request.Code;
                product.Description = request.Desciption;
                product.Price = request.Price;
                product.Stock = request.Stock;
                product.CategoryId = category.Id;

                return product;
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}