using AutoMapper;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;
using RapidRetail.Domain.Services;

namespace RapidRetail.Application.Services
{
    public class CartService(IMapper mapper, ICartRepository cartRepository, IProductRepository productRepository) : ICartService
    {
        public List<CartItemResponse> GetAllCartItems(int? userId)
        {
            if (userId == null)
                return new List<CartItemResponse>();

            var cartItems = cartRepository.GetCartItems(userId.Value);
            return mapper.Map<List<CartItemResponse>>(cartItems);
        }

        public CartItemResponse? AddCartItem(int? userId, AddCartItemRequestModel addCartItemModel)
        {
            if (userId == null)
                return  null;

            var product = productRepository.GetProducts().FirstOrDefault(p => p.Id == addCartItemModel.ProductId);
            if (product == null)
                return null;

            var cartItem = mapper.Map<CartItem>(addCartItemModel);
            cartItem.UserId = userId.Value;
            cartItem.Product = product;

            var addedItem = cartRepository.AddCartItem(cartItem);
            return mapper.Map<CartItemResponse>(addedItem);
        }

        public CartItemResponse UpdateCartItemQuantity(UpdateCartItemRequestModel cartItemModel)
        {
            var addedItem = cartRepository.UpdateItemQuantity(cartItemModel.ItemId, cartItemModel.Quantity);
            return mapper.Map<CartItemResponse>(addedItem);
        }

        public bool DeleteCartItem(int itemId) => cartRepository.DeleteCartItem(itemId);

        public bool CartItemExist(int productId) => cartRepository.CartItemExists(productId);

    }
}
