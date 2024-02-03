using AutoGlass.Products.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoGlass.Products.Infra.Contexts.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(b => b.CodigoProduto);
            builder.Property(b => b.CodigoProduto);   
            builder.Property(b => b.Descricao);
            builder.Property(b => b.Situacao).HasDefaultValue(true);
            builder.Property(b => b.DataFabricacao);
            builder.Property(b => b.DataValidade);
            builder.Property(b => b.CodigoFornecedor);
            builder.Property(b => b.CNPJFornecedor);
        }
    }
}
