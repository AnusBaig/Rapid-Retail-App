using Microsoft.Extensions.DependencyInjection;
using RapidRetail.Application.Services;
using RapidRetail.Domain.Services;

namespace RapidRetail.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ICartService, CartService>();

            return services;
        }
    }
}
