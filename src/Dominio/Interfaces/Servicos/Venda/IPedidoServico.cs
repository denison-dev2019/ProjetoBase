using Dominio.Dtos;
using Dominio.Dtos.Venda;
using Dominio.Interfaces.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public interface IPedidoServico: IServicoBase<PedidoDTO>
    {
        Task<PedidoDTO> Adicionar(PedidoDTO pedidoDTO);
        Task<PedidoDTO> Atualizar(PedidoDTO pedidoDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<PedidoDTO>> ListarTodos();
        Task<PedidoDTO> ObterPorId(int id);
    }
}
