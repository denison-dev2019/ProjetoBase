using Dominio.Dtos.Venda;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Venda
{
    public interface IPedidoFacadeServico
    {
        Task<PedidoGetDTO> ObterPorId(int id);
        Task<PedidoDTO> Adicionar(PedidoDTO pedido);
        Task<PedidoDTO> Atualizar(PedidoDTO pedido);
        Task<bool> Remover(int id);
        Task<bool> RemoverItem(int idPedido, int idItem);
    }
}
