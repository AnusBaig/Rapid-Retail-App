using RapidRetail.Domain.Entities;
using RapidRetail.Domain.Repositories;
using RapidRetail.Domain.Services;

namespace RapidRetail.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> FetchAllProducts()
        {
            var products = _productRepository.GetProducts();
            
            // TODO: Mapper can be implemented here, so we don't pass Database entities directly in API response
            return products;
        }
    }
}
