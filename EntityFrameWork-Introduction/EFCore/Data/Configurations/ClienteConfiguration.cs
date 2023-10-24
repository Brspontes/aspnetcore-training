using EFCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Data.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes");
            builder.HasKey(property => property.Id);
            builder.Property(property => property.Nome).HasColumnType("VARCHAR(80)").IsRequired();
            builder.Property(property => property.Telefone).HasColumnType("CHAR(11)");
            builder.Property(property => property.CEP).HasColumnType("CHAR(8)").IsRequired();
            builder.Property(property => property.Estado).HasColumnType("CHAR(2)").IsRequired();
            builder.Property(property => property.Cidade).HasMaxLength(60).IsRequired();

            builder.HasIndex(property => property.Telefone).HasDatabaseName("idx_cliente_telefone");
        }
    }
}
