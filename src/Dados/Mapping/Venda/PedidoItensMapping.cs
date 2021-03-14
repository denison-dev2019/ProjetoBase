using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dados.Mapping.Venda
{
    public class PedidoItensMapping : IEntityTypeConfiguration<PedidoItens>
    {
        public void Configure(EntityTypeBuilder<PedidoItens> builder)
        {
            builder.ToTable("PedidosItens");
            builder.HasKey(p => new { p.PedidoId, p.ProdutoId }); ;
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.PedidoId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.ProdutoId)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.QuantidadeProduto)
              .IsRequired()
              .HasColumnType("int");
            builder.Property(p => p.ValorUnitarioProduto)
             .IsRequired()
             .HasColumnType("decimal(18,2)");
            builder.Property(p => p.ValorDesconto)
             .HasColumnType("decimal(18,2)");

            builder.HasOne(p => p.Pedido)
              .WithMany(p => p.PedidoItens)
              .HasForeignKey(p => p.PedidoId)
              .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
