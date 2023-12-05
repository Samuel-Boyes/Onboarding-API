using Microsoft.AspNetCore.Mvc;
using Onboarding_API.Models;
using Onboarding_API.Services;
using Onboarding_API.ViewModels;

namespace Onboarding_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetProducts());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddUpdateProductVM model)
        {
            return Ok(await _productService.CreateProduct(model));
        }

        [HttpPatch]
        public async Task<IActionResult> Update([FromBody] Product product)
        {
            if(!_productService.ProductExists(product.Id))
            {
                return NotFound();
            }
            return Ok(await _productService.UpdateProduct(product));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Product product)
        {
            if (!_productService.ProductExists(product.Id))
            {
                return NotFound();
            }
            await _productService.DeleteProduct(product);
            return Ok();
        }


    }
}
