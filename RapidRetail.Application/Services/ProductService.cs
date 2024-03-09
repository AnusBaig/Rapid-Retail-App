using AutoMapper;
using RapidRetail.Domain.Aggregates;
using RapidRetail.Domain.Repositories;
using RapidRetail.Domain.Services;

namespace RapidRetail.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public List<ProductResponseModel> FetchAllProducts()
        {
            var products = _productRepository.GetProducts();

            // TODO: Mapper can be implemented here, so we don't pass Database entities directly in API response
            //List<ProductResponseModel> productResponse = new List<ProductResponseModel>();
            //foreach (var product in products)
            //{
            //    List<ProductResponseModel> productResponse= _mapper.Map<List<ProductResponseModel>>(products);
            //}
            return _mapper.Map<List<ProductResponseModel>>(products);
        }
    }
}
