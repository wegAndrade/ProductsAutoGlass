using AutoGlass.Products.Application.Entities;
using AutoGlass.Products.Application.Services;
using AutoGlass.Products.Application.Validators;
using AutoGlass.Products.Domain.Configuration;
using AutoGlass.Products.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AutoGlass.Products.Infra.Configuration;
namespace AutoGlass.Products.Application.Configuration
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection InjectApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.InjectInfra(configuration);
            services.InjectDomain();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ProductDtoValidation>();
            services.AddScoped<NotificationContext>();
            return services;
        }
    }
}
