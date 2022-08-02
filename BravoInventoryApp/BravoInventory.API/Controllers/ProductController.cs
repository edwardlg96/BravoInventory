using BravoInventory.Model;
using BravoInventory.Service;
using Microsoft.AspNetCore.Mvc;

namespace BravoInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        //Service Properties
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        //Constructor
        public ProductController(IProductService poductService, ICategoryService categoryService)
        {
            _productService = poductService;
            _categoryService = categoryService;
        }

        //Methods
        [HttpGet]
        [Route("get")]
        public List<Product> Get()
        {
            List<Product> products = _productService.GetAll().OrderByDescending(c => c.Id).ToList();

            return products;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Model.DTO.ProductDTO request)
        {
            try
            {
                if (_productService.ProductExists(request))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "A product with this code already exists. The new product could not be created.");
                }
                else
                {
                    Category category = _categoryService.Get(c => c.Code == request.CategoryCode);
                    if (category != null)
                    {
                        Product product = _productService.SetRequestForAdd(request, category);
                        _productService.Add(product);
                        _productService.SaveChanges();

                        return StatusCode(StatusCodes.Status201Created, "Product created successfully.");
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status409Conflict, "The provided category does not exists.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message); ;
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] Model.DTO.ProductDTO request)
        {
            try
            {
                if (_productService.ProductExists(request))
                {
                    Category category = _categoryService.Get(c => c.Code == request.CategoryCode);
                    if (category != null)
                    {
                        Product product = _productService.SetRequestForUpdate(request, category);
                        _productService.Update(product);
                        _productService.SaveChanges();
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status409Conflict, "The provided category does not exists.");
                    }

                    return StatusCode(StatusCodes.Status200OK, "Product modified successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status409Conflict, "The provided product does not exists.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            };
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = _productService.Get(p => p.Id == id);

            if (product != null)
            {
                _productService.Delete(product);
                _productService.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, "Product successfully deleted");
            }
            else
            {
                return StatusCode(StatusCodes.Status409Conflict, "The provided product id does not exists.");
            }

        }
    }

}
