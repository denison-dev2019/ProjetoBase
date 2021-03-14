using Dominio.Dtos.Venda;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Venda
{
    public interface IPedidoItensServico:IServicoBase<PedidoItensDTO>
    {
        Task<bool> Adicionar(PedidoItensDTO pedidoItensDTO);
        Task<bool> Atualizar(PedidoItensDTO pedidoItensDTO);
        Task<bool> Remover(int id);
        Task<IEnumerable<PedidoItensDTO>> ListarTodos(PedidoItensFiltroDTO filtro);
        Task<PedidoItensDTO> ObterPorId(int id);
    }
}
