using Dados.Contextos;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Repositorios.Cadastro;
using Dominio.Interfaces.Repositorios.Venda;
using Dominio.Interfaces.Uow;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Uow
{
    public class UnitOfWork : IUnitOfWork
    { 
        private readonly IServiceProvider _serviceProvider;
        private readonly ProjetoBaseDbContext _db;
        protected readonly Dictionary<Type, object> _repositorios = new Dictionary<Type, object>();

        public UnitOfWork(IServiceProvider serviceProvider, ProjetoBaseDbContext db)
        {
            _serviceProvider = serviceProvider;
            _db = db;
            _db.dbConnection = _db.Database.GetDbConnection();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        protected TRepositorio Configurar<TRepositorio>()
        {
            var chave = typeof(TRepositorio);

            lock (_repositorios)
            {
                if (!_repositorios.ContainsKey(chave))
                {
                    var repositorio = _serviceProvider.GetService(chave);

                    _repositorios.Add(chave, repositorio);
                }
            }

            return (TRepositorio)_repositorios[chave];
        }

        public IPedidoRepositorio Pedido  => Configurar<IPedidoRepositorio>();
        public IPedidoItensRepositorio PedidoItens => Configurar<IPedidoItensRepositorio>();
        public IProdutoRepositorio Produto => Configurar<IProdutoRepositorio>();
        public IPromocaoRepositorio Promocao => Configurar<IPromocaoRepositorio>();
        public IClienteRepositorio Cliente => Configurar<IClienteRepositorio>();

        public void BeginTransaction()
        {
            _db.BeginTransaction();
        }

        public void CommitTransaction()
        {
            SaveChanges();
            _db.CommitTransaction();
        }

        public int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public void Rollback()
        {
            _db.Rollback();
        }

    }
}
