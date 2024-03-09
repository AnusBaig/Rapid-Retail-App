using RapidRetail.Domain.Entities;

namespace RapidRetail.Domain.Repositories
{
    public interface ICartRepository
    {
        List<CartItem> GetCartItems(int userId);
        CartItem AddCartItem(CartItem cartItem);
        bool DeleteCartItem(int itemId);
        CartItem UpdateItemQuantity(int itemId, int quantity);
        bool CartItemExists(int productId);

    }
}
