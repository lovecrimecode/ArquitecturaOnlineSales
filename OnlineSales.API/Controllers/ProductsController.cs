using Microsoft.AspNetCore.Mvc;
using OnlineSales.Domain;
using OnlineSales.Application;
using OnlineSales.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineSales.API
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            var updated = await _productService.UpdateAsync(product);
            if (!updated) return NotFound(); // If no product was found, return 404
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteAsync(id);
            if (!deleted) return NotFound();
            return NoContent();
        }
    }
}