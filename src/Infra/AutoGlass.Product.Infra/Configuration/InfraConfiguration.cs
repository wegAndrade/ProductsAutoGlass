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
        public static IServiceCollection InjectInfra(this IServiceCollection services, IConfiguration configuration, string assemblyName)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AutoGlassProductsDbContext>(opt => opt.UseNpgsql(connectionString, b=> b.MigrationsAssembly(assemblyName)));
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
