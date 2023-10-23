using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netframe.Interfaces;
using netframe.Models;
using netframe.Repository;

namespace netframe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        // GET: CategoryController
        public IActionResult GetCategory()
        {
            var category = _categoryRepository.GetCategories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(category);
        }

        
    }
}
