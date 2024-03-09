using AutoMapper;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;

namespace RapidRetail.Application.Mappers
{
    internal class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<AddCartItemRequestModel, CartItem>();
            CreateMap<UpdateCartItemRequestModel, CartItem>();
            CreateMap<CartItem, CartItemResponse>().ReverseMap();
        }
    }
}
