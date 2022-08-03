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
                    Description = request.Description,
                    UnitPrice = request.UnitPrice,
                    Quantity = request.Quantity,
                    CategoryId = category.Id,
                    CreateDate = DateTime.Now
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
                product.Description = request.Description != "" ? request.Description : product.Description;
                product.UnitPrice = request.UnitPrice > 0 ? request.UnitPrice : product.UnitPrice;
                product.Quantity = request.Quantity > 0 ? request.Quantity : product.Quantity; ;
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