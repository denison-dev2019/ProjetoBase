using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapping.Cadastro
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");
            builder.Property(p => p.Preco)
               .IsRequired()
               .HasColumnType("decimal(18,2)");
            builder.Property(p => p.PromocaoId)
              .IsRequired()
              .HasColumnType("int");
        }
    }
}
