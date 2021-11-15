using Identity.Domain.Interfaces;
using Identity.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.API.Extensions
{
    public static class AppServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }

    }
}