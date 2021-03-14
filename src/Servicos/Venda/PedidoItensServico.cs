using Crosscutting.Utilitarios;
using Dominio.Dtos.Venda;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Venda;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.Venda
{
    public class PedidoItensServico : ServicoBase<PedidoItensDTO>, IPedidoItensServico
    {
        public PedidoItensServico(IServiceProvider serviceProvider) : base(serviceProvider) { }

        public async Task<bool> Adicionar(PedidoItensDTO pedidoItensDTO)
        {
            if (await _unitOfWork.PedidoItens.ExisteAsync(p => p.Id == pedidoItensDTO.Id))
            {
                Notificar("Este Item já existe para este pedido.");
                return false;
            }
            await _unitOfWork.PedidoItens.AdicionarAsync(_mapper.Map<PedidoItens>(pedidoItensDTO));
            _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<bool> Atualizar(PedidoItensDTO pedidoItensDTO)
        {
            if(!await _unitOfWork.PedidoItens.ExisteAsync(p => p.Id == pedidoItensDTO.Id))
            { 
                    Notificar("Este Item não existe neste pedido.");
                    return false;
            }
            await _unitOfWork.PedidoItens.AtualizarAsync(_mapper.Map<PedidoItens>(pedidoItensDTO));
            _unitOfWork.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<PedidoItensDTO>> ListarTodos(PedidoItensFiltroDTO filtro)
        {
            return _mapper.Map<List<PedidoItensDTO>>(
                await _unitOfWork.PedidoItens.Obter(x => x.PedidoId == filtro.PedidoId));
        }

        public async Task<PedidoItensDTO> ObterPorId(int id)
        {
            return _mapper.Map<PedidoItensDTO>(await _unitOfWork.PedidoItens.ObterPorId(id));
        }

        public async Task<bool> Remover(int id)
        {
            if (!await _unitOfWork.PedidoItens.ExisteAsync(x =>x.Id == id))
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(id)));
                return false;
            }

            _unitOfWork.BeginTransaction();
            await _unitOfWork.PedidoItens.RemoverAsync(id);
            _unitOfWork.CommitTransaction();
            return true;
        }
    }
}
