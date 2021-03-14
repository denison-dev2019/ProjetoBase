using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dados.Mapping
{
    public class PedidoMapping: IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.Valor)
                .IsRequired()
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnType("BIT");
            builder.Property(p => p.ClienteId)
              .IsRequired()
              .HasColumnType("int");
            builder.HasMany(p => p.PedidoItens)
              .WithOne(p => p.Pedido)
              .HasForeignKey(p => p.PedidoId)
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
