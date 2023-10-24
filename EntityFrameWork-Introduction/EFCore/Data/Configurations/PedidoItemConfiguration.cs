using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class PedidoItemConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {

            builder.ToTable("PedidoItens");
            builder.HasKey(property => property.Id);
            builder.Property(property => property.Quantidade).HasDefaultValue(1).IsRequired();
            builder.Property(property => property.Valor).IsRequired();
            builder.Property(property => property.Desconto).IsRequired();

        }
    }
}
