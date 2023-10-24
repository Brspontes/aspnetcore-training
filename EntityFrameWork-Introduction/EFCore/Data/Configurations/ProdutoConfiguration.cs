using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(property => property.Id);
            builder.Property(property => property.CodigoBarras).HasColumnType("VARCHAR(14)").IsRequired();
            builder.Property(property => property.Descricao).HasColumnType("VARCHAR(60)");
            builder.Property(property => property.Valor).IsRequired();
            builder.Property(property => property.TipoProduto).HasConversion<string>();

        }
    }
}
