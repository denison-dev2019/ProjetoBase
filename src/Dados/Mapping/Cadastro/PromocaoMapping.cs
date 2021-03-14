using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapping.Cadastro
{
    public class PromocaoMapping: IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.ToTable("Promocao");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.Descricao)
               .IsRequired()
               .HasColumnType("varchar(100)");
            builder.Property(p => p.Formula)
               .IsRequired()
               .HasColumnType("varchar(100)");
            builder.Property(p => p.Acumulativa)
              .IsRequired()
              .HasColumnType("bit");
        }
    }
}
