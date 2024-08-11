using Domain.Entities;
using Domain.Ports.IProduct;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OrderManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService) => _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetOrListProductAsync(0);

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            if (id <= 0) return BadRequest();

            var products = await _productService.GetOrListProductAsync(id);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> InserProduct([FromBody] Product product)
        {
            var productInserted = await _productService.InsertProductAsync(product);

            return Ok(productInserted);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product?.Id) return BadRequest();

            var productUpdated = await _productService.UpdateProductAsync(product);
            
            return Ok(productUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if(id <= 0) return BadRequest();

            var productDeleted = await _productService.DeleteProductAsync(id);

            return Ok(productDeleted);
        }
    }
}
