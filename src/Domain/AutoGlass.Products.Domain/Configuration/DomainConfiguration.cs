using AutoGlass.Products.Domain.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AutoGlass.Products.Domain.Configuration
{
    public static class DomainConfiguration
    {
        public static IServiceCollection InjectDomain(this IServiceCollection services)
        {
       
            services.AddAutoMapper(cfg => cfg.AddProfile<DtoToDomainProfile>());
            return services;
        }
    }
}
