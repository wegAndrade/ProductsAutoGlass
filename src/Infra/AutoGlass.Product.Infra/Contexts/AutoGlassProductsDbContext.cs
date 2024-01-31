using AutoGlass.Products.Domain.Entities;
using AutoGlass.Products.Infra.Contexts.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Products.Infra.Contexts
{
    public class AutoGlassProductsDbContext : DbContext
    {
        public AutoGlassProductsDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
