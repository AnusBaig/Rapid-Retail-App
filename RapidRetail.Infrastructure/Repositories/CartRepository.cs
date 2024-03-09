using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;

namespace RapidRetail.Infrastructure.Repositories
{
    public class CartRepository : ICartRepository
    {

        private static List<CartItem> _items = new();

        public List<CartItem> GetCartItems(int userId)
        {
            return _items.Where(i => i.UserId == userId && i.Quantity > 0).ToList();
        }

        public CartItem? GetCartItemById(int itemId)
        {
            return _items.FirstOrDefault(i => i.Id == itemId);
        }

        public CartItem AddCartItem(CartItem cartItem)
        {
            var maxId = _items.Count > 0 ? _items.Max(i => i.Id): 0;
            cartItem.Id = maxId + 1;
            _items.Add(cartItem);

            return cartItem;
        }

        public bool DeleteCartItem(int itemId)
        {
            var cartItem = GetCartItemById(itemId);
            if (cartItem == null)
                return false;

            _items.Remove(cartItem);
            return true;
        }

        public CartItem? UpdateItemQuantity(int itemId, int quantity)
        {
            var cartItem = GetCartItemById(itemId);
            if (cartItem != null)
                cartItem.Quantity = quantity;

            return cartItem;
        }

        public bool CartItemExists(int productId) => _items.Any(i => i.Product.Id == productId);

    }
}
