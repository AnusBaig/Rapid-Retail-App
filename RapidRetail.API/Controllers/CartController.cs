using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Services;
using RapidRetail.Infrastructure.Services;

namespace RapidRetail.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICartService _cartService;
        private readonly int? _userId;

        public CartController(ILogger<ProductController> logger, IHttpContextAccessor context, ICartService cartService)
        {
            _logger = logger;
            _cartService = cartService;
            _userId = JwtService.GetUserId(context);
        }

        // GET: api/<ProductController>
        [HttpGet("all")]
        public IActionResult GetAllCartItems()
        {
            try
            {
                var products = _cartService.GetAllCartItems(_userId);
                return Ok(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}", ex.Message);
                return NotFound("No product available in the system");
            }
        }


        // POST api/<ProductController>
        [HttpPost]
        public IActionResult AddItemInCart([FromBody] AddCartItemRequestModel requestModel)
        {
            try
            {
                if (_cartService.CartItemExist(requestModel.ProductId))
                    return BadRequest("Item is already added in the Cart");

                var cartItem = _cartService.AddCartItem(_userId, requestModel);

                if (cartItem != null)
                    return Ok(cartItem);
                else
                    return BadRequest("Unable to add item in Cart");

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}", ex.Message);
                return BadRequest("Unable to add item in Cart");
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public IActionResult UpdateItemQuantiy(UpdateCartItemRequestModel requestModel)
        {
            try
            {
                var cartItem = _cartService.UpdateCartItemQuantity(requestModel);
                if (cartItem != null)
                    return Ok(cartItem);
                else
                    return BadRequest("Unable to update the quantity of selected item in cart");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}", ex.Message);
                return BadRequest("Unable to update the quantity of selected item in cart");
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteItemFromCart(int id)
        {
            try
            {
                var isDeleted = _cartService.DeleteCartItem(id);
                return isDeleted ? Ok("Item deleted from Cart successfully") : BadRequest("Unable to remove item from thr Cart");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{message}", ex.Message);
                return BadRequest("Unable to remove item from thr Cart");
            }
        }
    }
}
