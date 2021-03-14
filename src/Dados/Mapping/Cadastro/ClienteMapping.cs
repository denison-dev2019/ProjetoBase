using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Mapping.Cadastro
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("clientes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .IsRequired()
                .HasColumnType("int");
            builder.Property(p => p.Nome)
               .IsRequired()
               .HasColumnType("varchar(100)");
            builder.Property(p => p.cep)
           .IsRequired()
           .HasColumnType("varchar(100)");
        }
    }
}
