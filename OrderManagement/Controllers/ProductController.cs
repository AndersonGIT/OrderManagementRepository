using Domain.Entities;
using Domain.Ports.IProduct;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            if (productId <= 0) return BadRequest();

            var products = await _productService.GetOrListProductAsync(productId);
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> InserProduct([FromBody] Product product)
        {
            if (product.Validate())
            {
                var productInserted = await _productService.InsertProductAsync(product);

                return Ok(productInserted);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] Product product)
        {
            if (product.Validate())
            {
                if (productId != product?.Id) return BadRequest();

                var productUpdated = await _productService.UpdateProductAsync(product);

                return Ok(productUpdated);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            if(productId <= 0) return BadRequest();

            var productDeleted = await _productService.DeleteProductAsync(productId);

            return Ok(productDeleted);
        }
    }
}
