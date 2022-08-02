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

        //Constructor
        public ProductController(IProductService poductService)
        {
            _productService = poductService;
        }

        [HttpGet]
        [Route("get")]
        public List<Product> Get()
        {
            List<Product> products = _productService.GetAll().OrderByDescending(c => c.Id).ToList();

            return products;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Product request)
        {
            _productService.Add(request);
            _productService.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, "Product successfully added");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] Product request)
        {
            _productService.Update(request);
            _productService.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, "Product successfully modified");
        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product category = _productService.Get(c => c.Id == id);

            _productService.Delete(category);
            _productService.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, "Product successfully deleted");
        }
    }

}
