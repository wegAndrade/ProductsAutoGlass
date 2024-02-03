using AutoGlass.Products.Domain.Dto_s;
using AutoGlass.Products.Domain.Entities;

namespace AutoGlass.Products.Domain.Interfaces.Services
{
    public interface IProductService
    {
        Task<int> Add(ProductDto productDto);
        Task Update(ProductDto productDto, int productId);
        Task Delete(int productId);
        Task<Product> GetById(int id);
        Task<IEnumerable<Product>> GetAll();
    }
}
