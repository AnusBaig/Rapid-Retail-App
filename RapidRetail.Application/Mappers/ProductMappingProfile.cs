using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Entities;

namespace RapidRetail.Application.Mappers
{
    internal class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductResponseModel>().ReverseMap();
        }
    }
}
