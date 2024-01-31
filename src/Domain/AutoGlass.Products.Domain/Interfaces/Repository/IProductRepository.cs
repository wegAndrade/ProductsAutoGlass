using AutoGlass.Products.Domain.Entities;

namespace AutoGlass.Products.Domain.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task Add(Product product);
        Task Update(Product product);
        Task Delete(Product product);
        Task<Product?> GetById(int id);
        Task<IEnumerable<Product>> GetAll();


    }

}
