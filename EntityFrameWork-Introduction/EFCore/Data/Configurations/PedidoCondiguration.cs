using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class PedidoCondiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(property => property.Id);
            builder.Property(property => property.IniciadoEm).HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
            builder.Property(property => property.StatusPedido).HasConversion<string>();
            builder.Property(property => property.TipoFrete).HasConversion<int>();
            builder.Property(property => property.StatusPedido).HasColumnType("VARCHAR(512)");

            builder.HasMany(property => property.Itens)
                    .WithOne(property => property.Pedido)
                    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
