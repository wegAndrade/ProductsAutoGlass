using AutoGlass.Products.Domain.Dto_s;
using AutoGlass.Products.Domain.Entities;
using AutoMapper;

namespace AutoGlass.Products.Domain.AutoMapper
{
    public class DtoToDomainProfile : Profile
    {
        public DtoToDomainProfile()
        {
            CreateMap<ProductDto, Product>();
        }
    }
}
