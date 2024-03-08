using Microsoft.Extensions.DependencyInjection;
using RapidRetail.Application.Services;
using RapidRetail.Domain.Services;

namespace RapidRetail.Infrastructure
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
