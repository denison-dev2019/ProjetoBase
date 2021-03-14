using Dominio.Interfaces.Contextos;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Repositorios.Cadastro;
using Dominio.Interfaces.Repositorios.Venda;
using System;

namespace Dominio.Interfaces.Uow
{
    public interface IUnitOfWork: IContexto, IDisposable
    {
        IPedidoRepositorio Pedido { get; }
        IPedidoItensRepositorio PedidoItens { get; }
        IProdutoRepositorio Produto { get; }
        IPromocaoRepositorio Promocao { get; }
        IClienteRepositorio Cliente { get; }
    }
}
