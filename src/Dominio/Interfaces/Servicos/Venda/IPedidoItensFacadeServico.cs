using Dominio.Dtos.Venda;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Venda
{
    public interface IPedidoItensFacadeServico
    {
        Task<IEnumerable<PedidoItensDTO>> ListarTodos(PedidoItensFiltroDTO filtro);
        Task<bool> Remover(int id);
    }
}
