using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using netframe.DTO;
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
        private readonly IMapper _mapper;

        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
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

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(Guid categoryId)
        {
            if (!_categoryRepository.ExistCategory(categoryId))
                return NotFound();
            var category = _categoryRepository.GetCategory(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateCategory([FromBody] CategoryDTO categoryCreate)
        {
            if (categoryCreate == null)
                return BadRequest(ModelState);

            var category = _categoryRepository.GetCategories()
                .Where(c => c.Name.Trim().ToUpper() == categoryCreate.Name.Trim().ToUpper())
                .FirstOrDefault();
            if (category != null)
            {
                ModelState.AddModelError("", "Category already exists");
                return StatusCode(402, ModelState);
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryMap = _mapper.Map<Category>(categoryCreate);

            if (!_categoryRepository.CreateCategory(categoryMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }

        [HttpPut("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCategory(Guid categoryId, [FromBody]CategoryDTO updateCategory)
        {
            if (updateCategory == null)
                return BadRequest(ModelState);

            if (categoryId != updateCategory.CategoryId)
                return BadRequest(ModelState);

            if (!_categoryRepository.ExistCategory(categoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categorytMap = _mapper.Map<Category>(updateCategory);

            if (!_categoryRepository.UpdateCategory(categorytMap))
            {
                ModelState.AddModelError("", "Something went wwrong updating product");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCategory(Guid categoryId)
        {

            if (!_categoryRepository.ExistCategory(categoryId))
                return NotFound();

            var categoryDelete = _categoryRepository.GetCategory(categoryId);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_categoryRepository.DeleteCategory(categoryDelete))
            {
                ModelState.AddModelError("", "Something went wwrong deleting product");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
