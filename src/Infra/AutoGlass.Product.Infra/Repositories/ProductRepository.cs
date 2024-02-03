using AutoGlass.Products.Domain.Entities;
using AutoGlass.Products.Domain.Interfaces.Repository;
using AutoGlass.Products.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Products.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AutoGlassProductsDbContext _context;

        public ProductRepository(AutoGlassProductsDbContext context)
        {
            _context = context;
        }

        public async Task Add(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _context.Products.AsNoTracking().Where(p => p.Situacao).ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.CodigoProduto == id && p.Situacao);
        }

        public async Task Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
