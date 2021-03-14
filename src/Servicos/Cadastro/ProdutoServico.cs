using Crosscutting.Utilitarios;
using Dominio.DTO.Validador.Cadastro;
using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Dominio.Interfaces.Servicos.Cadastro;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Servicos.Cadastro
{
    public class ProdutoServico : ServicoBase<Produto>, IProdutoServico
    {

        public ProdutoServico(IServiceProvider serviceProvicer) : base(serviceProvicer) { }

        public async Task<ProdutoDTO> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ExecutarValidacao(new ProdutoValidator(), produtoDTO)) return null;
            
            if (produtoDTO.Id > 0 || (await _unitOfWork.Produto.ObterPorId(produtoDTO.Id)) != null)
            {
                Notificar(ValidationMessage.RegistroJaExistente(nameof(produtoDTO.Id)));
                return null;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Produto.AdicionarAsync(_mapper.Map<Produto>(produtoDTO));
            _unitOfWork.CommitTransaction();
            return produtoDTO;
        }

        public async Task<ProdutoDTO> Atualizar(int id, ProdutoDTO produtoDTO)
        {
            if (!ExecutarValidacao(new ProdutoValidator(), produtoDTO)) return null;
            if (await (_unitOfWork.Produto.ObterPorId(id)) == null)
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(produtoDTO.Id)));
                return null;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Produto.AtualizarAsync(_mapper.Map<Produto>(produtoDTO));
            _unitOfWork.CommitTransaction();
            return produtoDTO;
        }

        public async Task<List<ProdutoGetDTO>> ListarTodos()
        {
            var produtos = await _unitOfWork.Produto.Obter();
            return await  BuscarPromocaoPorProduto(_mapper.Map<List<ProdutoGetDTO>>(produtos));
        }

        public async Task<ProdutoGetDTO> ObterPorId(int id)
        {
            var produto = _mapper.Map<ProdutoGetDTO>(await _unitOfWork.Produto.ObterPorId(id));
            return produto != null? await BuscarPromocaoPorProduto(produto): null;
        }

        public async Task<bool> Remover(int id)
        {
            if (await _unitOfWork.Produto.ObterPorId(id) == null)
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(id)));
                return false;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Produto.RemoverAsync(await _unitOfWork.Produto.ObterPorId(id));
            _unitOfWork.CommitTransaction();
            return true;
        }

        private async Task<List<ProdutoGetDTO>> BuscarPromocaoPorProduto(List<ProdutoGetDTO> produtos)
        {
            var listaProdutos = new List<ProdutoGetDTO>();
            foreach (var produto in produtos)
            {
                produto.Promocao = produto.PromocaoId > 0 ?
                    _mapper.Map<PromocaoDTO>(await _unitOfWork.Promocao.ObterPorId(produto.PromocaoId))
                    : null;
                listaProdutos.Add(produto);
            }
            return listaProdutos;
        }

        private async Task<ProdutoGetDTO> BuscarPromocaoPorProduto(ProdutoGetDTO produto)
        {
            produto.Promocao = produto.PromocaoId > 0 ?
                      _mapper.Map<PromocaoDTO>(await _unitOfWork.Promocao.ObterPorId(produto.PromocaoId))
                      : null;
            return produto;
        }

    }
}
