using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.Api.Abstraction;
using ShopBridge.Api.Model;
using ShopBridge.Api.Service;

namespace ShopBridge.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController()
        {
            _productService = new ProductService();          
        }

        [HttpPost("create-update-product")]
        public async Task<IActionResult> UpsertProductAsync(IEnumerable<Product> createProductCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _productService.UpsertProductAsync(createProductCommand));
        }

        [HttpGet]
        [Route("Products")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpDelete("delete-product")]
        public async Task<IActionResult> DeleteProductAsync(DeleteProductCommand deleteProductCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _productService.DeleteProductAsync(deleteProductCommand));
        }
    }
}
