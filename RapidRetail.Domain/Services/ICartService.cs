using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Services
{
    public interface ICartService
    {
        List<CartItemResponse> GetAllCartItems(int? userId);
        CartItemResponse? AddCartItem(int? userId, AddCartItemRequestModel addCartItemModel);
        CartItemResponse UpdateCartItemQuantity(UpdateCartItemRequestModel updateCartItemModel);
        bool DeleteCartItem(int itemId);
        bool CartItemExist(int productId);

    }
}
