using BravoInventory.Model;
using BravoInventory.Service;
using Microsoft.AspNetCore.Mvc;

namespace BravoInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        //Service Properties
        private readonly ICategoryService _categoryService;

        //Constructor
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Category> categories = _categoryService.GetAll().OrderByDescending(c => c.Id).ToList();

                return StatusCode(StatusCodes.Status200OK, categories);
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Category request)
        {
            try
            {
                _categoryService.Add(request);
                _categoryService.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, "Category added successfully");
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] Category request)
        {
            try
            {
                _categoryService.Update(request);
                _categoryService.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, "Category modified successfully");
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

        }

        [HttpDelete]
        [Route("delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Category category = _categoryService.Get(c => c.Id == id);

                _categoryService.Delete(category);
                _categoryService.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, "OK");
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }

        }
    }

}
