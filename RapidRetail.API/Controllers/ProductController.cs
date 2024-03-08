using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidRetail.Domain.Services;

namespace RapidRetail.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(ILogger<ProductController> logger, IProductService productService)
        : ControllerBase
    {
        // GET: api/<ProductController>
        [HttpGet("all")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = productService.FetchAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "{message}", ex.Message);
                return NotFound("No product available in the system");
            }
        }
    }
}
