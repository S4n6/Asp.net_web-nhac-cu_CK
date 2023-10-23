using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using netframe.DTO;
using netframe.Interfaces;
using netframe.Models;

namespace netframe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductController(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Product>))]
        public IActionResult GetProducts()
        {
            var product = _mapper.Map<List<ProductDTO>>(_productRepository.GetProducts());

            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(product);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(200, Type = typeof(Product))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(Guid productId)
        {
            if(!_productRepository.ProductExist(productId))
                return NotFound();
            var product = _productRepository.GetProduct(productId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody]ProductDTO productCreate)
        {
            if(productCreate == null)
                return BadRequest(ModelState);

            var product = _productRepository.GetProducts()
                .Where(c=>c.Name.Trim().ToUpper() == productCreate.Name.Trim().ToUpper())
                .FirstOrDefault();
            if(product != null)
            {
                ModelState.AddModelError("", "Product already exists");
                return StatusCode(402, ModelState);
            }    
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var productMap = _mapper.Map<Product>(productCreate);

            if(!_productRepository.CreateProduct(productMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }
            return Ok("Successfully created");
        }
    }
}
