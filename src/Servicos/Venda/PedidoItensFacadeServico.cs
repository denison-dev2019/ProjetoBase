using Dominio.Dtos.Venda;
using Dominio.Interfaces.Servicos.Cadastro;
using Dominio.Interfaces.Servicos.Venda;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicos.Venda
{
    public class PedidoItensFacadeServico: IPedidoItensFacadeServico
    {
        private readonly IPedidoItensFacadeServico _pedidoItensFacadeServico;
        private readonly IProdutoServico _produtoServico;
        public PedidoItensFacadeServico(IPedidoItensFacadeServico pedidoItensFacadeServico,
            IProdutoServico produtoServico)
        {
            _pedidoItensFacadeServico = pedidoItensFacadeServico;
            _produtoServico = produtoServico;
        }

        public async Task<IEnumerable<PedidoItensDTO>> ListarTodos(PedidoItensFiltroDTO filtro)
        {
            var itens = await _pedidoItensFacadeServico.ListarTodos(filtro);
            foreach (var item in itens)
                item.Produto = await _produtoServico.ObterPorId(item.ProdutoId);
            return itens;
        }

        public async Task<bool> Remover(int id)=> await _pedidoItensFacadeServico.Remover(id);
    }
}
