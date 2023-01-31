using Basic.Auth.Core.Interfaces.ProductInterface;
using Basic.Auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BasicAtWebApiAuthentication.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _product;

        public ProductController(IProductServices product)
        {
            _product = product;
        }
        [HttpGet("Get-A-Product")]
        public async Task<ActionResult<Product>> GetAProduct(int id)
        {
            var product = await _product.GetAProductAsync(id);
            return   Ok(product);
        }
        [HttpPost("Add-A-Product")]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            await _product.AddAProductAsync(product);
            return Ok();
        }
        [HttpGet("Get-All-Product")]
        public async Task<ActionResult<Product>> GetAllProduct()
        {
            var products = await _product.GetProductsAsync();
            return Ok(products);
        }
        [HttpDelete("Delete_A_Product")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
             await _product.DeleteAProductAsync(id);
            return Ok();
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            await _product.UpdateProductAsync(product);
            return Ok();
        }
    }
}
