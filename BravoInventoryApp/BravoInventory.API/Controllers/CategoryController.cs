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

        //Methods
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
        public async Task<IActionResult> Create([FromBody] Model.DTO.CategoryDTO request)
        {
            try
            {
                if (_categoryService.CategoryExists(request))
                {
                    return StatusCode(StatusCodes.Status409Conflict, "A Category with this code already exists. The new category could not be created.");
                }
                else
                {
                    Category category = _categoryService.SetRequestForAdd(request);
                    _categoryService.Add(category);
                    _categoryService.SaveChanges();

                    return StatusCode(StatusCodes.Status201Created, "Category created successfully.");
                }

            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] Model.DTO.CategoryDTO request)
        {
            try
            {
                if (_categoryService.CategoryExists(request))
                {
                    Category category = _categoryService.SetRequestForUpdate(request);
                    _categoryService.Update(category);
                    _categoryService.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, "Category modified successfully.");
                }
                else
                {
                    return StatusCode(StatusCodes.Status304NotModified, "The category provided does not exists.");

                }

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

                if (category != null)
                {
                    _categoryService.Delete(category);
                    _categoryService.SaveChanges();

                    return StatusCode(StatusCodes.Status200OK, "Category deleted successfully.");
                }

                return StatusCode(StatusCodes.Status409Conflict, "The category could not be deleted. There is no category with id " + category.Id + " in the system.");
            }
            catch (Exception ex)
            {
                throw new Exception((ex.InnerException != null) ? ex.InnerException.Message : ex.Message);
            }
        }
    }

}
