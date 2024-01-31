using AutoGlass.Products.Domain.Interfaces.Repository;
using AutoGlass.Products.Infra.Contexts;
using AutoGlass.Products.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.Products.Infra.Configuration
{
    public static class InfraConfiguration
    {
        public static IServiceCollection InjectInfra(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");

            services.AddDbContext<AutoGlassProductsDbContext>(opt => opt.UseSqlServer(connectionString));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
