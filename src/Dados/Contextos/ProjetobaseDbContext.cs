using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Dominio.Interfaces.Contextos;
using Dominio.Entidades;
using System.Data;

namespace Dados.Contextos
{
    public sealed class ProjetoBaseDbContext : DbContext, IDisposable
    {
        public DbConnection dbConnection;
        private IDbContextTransaction _transaction;
        
        public ProjetoBaseDbContext(DbContextOptions<ProjetoBaseDbContext> options) : base(options)
        {
         //   ChangeTracker.AutoDetectChangesEnabled = false;
        }

        #region DBSet
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PedidoItens> PedidosItens { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Promocao> Promocoes { get; set; }

        #endregion
        /* protected override void OnModelCreating(ModelBuilder builder)
         {
             builder.ApplyConfigurationsFromAssembly(typeof(ProjetoBaseDbContext).Assembly);

             base.OnModelCreating(builder);
         }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=LojaVirtual;User Id=sa;Password=cep31573420;");
        }

        public void CloseConnection()
        {
            if (!dbConnection.State.Equals(ConnectionState.Closed)) dbConnection.Close();
        }

        public void BeginTransaction() => _transaction = Database.BeginTransaction();

        public void CommitTransaction() => Database.CommitTransaction();

        public void Rollback()
        {
            _transaction.Rollback();
            _transaction.Dispose();
        }


        public override void Dispose()
        {
            if (_transaction != null)
                _transaction.Dispose();

            dbConnection?.Close();
            GC.SuppressFinalize(this);
        }
        
    }
}


