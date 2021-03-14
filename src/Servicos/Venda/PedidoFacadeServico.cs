using Dominio.Dtos.Venda;
using Dominio.Interfaces.Servicos.Cadastro;
using Dominio.Interfaces.Servicos.Venda;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.Venda
{
    public class PedidoFacadeServico : ServicoBase<PedidoGetDTO>, IPedidoFacadeServico
    {
        private readonly IPedidoServico _pedidoServico;
        private readonly IPedidoItensServico _pedidoItensServico;
        private readonly Lazy<IClienteServico> _clienteServico;
        private readonly IProdutoServico _produtoServico;
        private readonly IPromocaoServico _promocaoServico;
        public PedidoFacadeServico(IServiceProvider serviceProvider, IPedidoServico pedidoServico,
            IPedidoItensServico pedidoItensServico, Lazy<IClienteServico> clienteServico, IProdutoServico produtoServico,
            IPromocaoServico promocaoServico) : base(serviceProvider)
        {
            _pedidoServico = pedidoServico;
            _clienteServico = clienteServico;
            _pedidoItensServico = pedidoItensServico;
            _produtoServico = produtoServico;
            _promocaoServico = promocaoServico;
        }

        public async Task<PedidoDTO> Adicionar(PedidoDTO pedidoDTO) => await _pedidoServico.Adicionar(pedidoDTO);

        public async Task<PedidoDTO> Atualizar(PedidoDTO pedidoDTO) =>  await _pedidoServico.Atualizar(pedidoDTO);

        public async Task<PedidoGetDTO> ObterPorId(int id)
        {
            var pedido = await _pedidoServico.ObterPorId(id);
            var pedidoGet = _mapper.Map<PedidoGetDTO>(pedido);
            if (pedidoGet == null) return null;
            pedidoGet.Cliente = await _clienteServico.Value.ObterPorId(pedido.ClienteId);
            pedidoGet.PedidoItens = await BuscarProdutosPorItens(
                await _pedidoItensServico.ListarTodos(new PedidoItensFiltroDTO { PedidoId = id }));
            return pedidoGet;
        }

        public async Task<bool> Remover(int id) => await _pedidoServico.Remover(id);

        public async Task<bool> RemoverItem(int idPedido , int idItem)
        {
            if(await _pedidoItensServico.Remover(idItem));
                await Atualizar(_mapper.Map<PedidoDTO>(await ObterPorId(idPedido)));
            return true;
        }

        #region MÉTODOS PRIVADOS
        private async Task<IEnumerable<PedidoItensDTO>> BuscarProdutosPorItens(IEnumerable<PedidoItensDTO> itens)
        {
            foreach (var item in itens)
                item.Produto = await _produtoServico.ObterPorId(item.ProdutoId);
            
            return itens;
        }
        #endregion

    }
}
