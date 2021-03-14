using Crosscutting.Enuns;
using Crosscutting.Utilitarios;
using Dominio.Dtos;
using Dominio.Dtos.Cadastro;
using Dominio.Dtos.Venda;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios.Cadastro;
using Dominio.Interfaces.Servicos.Cadastro;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicos
{
    public class PedidoServico : ServicoBase<PedidoDTO>, IPedidoServico
    {
        private readonly IPromocaoServico _promocaoServico;
        public PedidoServico(IServiceProvider serviceProvider, IPromocaoServico promocaoServico) : base(serviceProvider) 
        {
            _promocaoServico = promocaoServico;
        }
        public async Task<PedidoDTO> Adicionar(PedidoDTO pedidoDTO)
        {
          if (await _unitOfWork.Pedido.ExisteAsync(p => p.Id == pedidoDTO.Id))
          {
               Notificar("Este pedido já existe.");
               return null;
          }
            
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Pedido.AdicionarAsync(
                _mapper.Map<Pedido>(await AtualizarValorPedido(pedidoDTO)));
            _unitOfWork.CommitTransaction();
            return pedidoDTO;
        }

        public async Task<PedidoDTO> Atualizar(PedidoDTO pedidoDTO)
        {
            if (!_unitOfWork.Pedido.Obter(p => p.Id == pedidoDTO.Id).Result.Any())
            {
                Notificar("Não foi possivel atualizar. Pedido inexistente");
                return null;
            }
            
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Pedido.AtualizarAsync(
                _mapper.Map<Pedido>(await AtualizarValorPedido(pedidoDTO)));
            _unitOfWork.CommitTransaction();
            return pedidoDTO;
        }

        public async Task<IEnumerable<PedidoDTO>> ListarTodos() => 
            _mapper.Map<IEnumerable<PedidoDTO>>(await _unitOfWork.Pedido.Obter());
        

        public async Task<PedidoDTO> ObterPorId(int id) => 
            _mapper.Map<PedidoDTO>(await _unitOfWork.Pedido.ObterPorId(id));

        public async Task<bool> Remover(int id)
        {
            if ((await _unitOfWork.Pedido.ObterPorId(id)) == null)
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(id)));
                return false;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Pedido.RemoverAsync(id);
            _unitOfWork.CommitTransaction();
            return true;
        }

        private async Task<PedidoDTO> AtualizarValorPedido(PedidoDTO pedido) 
        {
            pedido.PedidoItens = await BuscarValorProduto(pedido.PedidoItens); //
            pedido.Valor = pedido.PedidoItens
                .Sum(x => (x.QuantidadeProduto * x.ValorUnitarioProduto) - x.ValorDesconto);
            return pedido;
        }

        private async Task<IEnumerable<PedidoItensDTO>> BuscarValorProduto(IEnumerable<PedidoItensDTO> itens)
        {
            foreach (var item in itens) 
            {
                var newItem = _mapper.Map<ProdutoGetDTO>(await _unitOfWork.Produto.ObterPorId(item.ProdutoId));
                item.ValorUnitarioProduto = newItem.Preco;
                item.ValorDesconto = await _promocaoServico.AplicarFormula(newItem.Preco, item.QuantidadeProduto, newItem.PromocaoId);
            }

            return itens;
        }

    }
}
