using Crosscutting.Utilitarios;
using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Cadastro;
using Servicos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servicos.Cadastro
{
    public class PromocaoServico : ServicoBase<PromocaoDTO>, IPromocaoServico
    {
        private int qtdLeve;
        private int qtdPromocaoAplicada;
        private PromocaoDTO promocao;
        public PromocaoServico(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
        public async Task<PromocaoDTO> ObterPorId(int id) =>
            _mapper.Map<PromocaoDTO>(await _unitOfWork.Promocao.ObterPorId(id));

        public async Task<List<PromocaoDTO>> ListarTodos() =>
            _mapper.Map<List<PromocaoDTO>>(await _unitOfWork.Promocao.Obter());

        public async Task<PromocaoDTO> Adicionar(PromocaoDTO promocaoDTO)
        {
            if ( await _unitOfWork.Promocao.ExisteAsync(x => x.Descricao == promocaoDTO.Descricao) )
            {
                Notificar(ValidationMessage.RegistroJaExistente(nameof(promocaoDTO.Descricao)));
                return null;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Promocao.AdicionarAsync(_mapper.Map<Promocao>(promocaoDTO));
            _unitOfWork.CommitTransaction();
            return promocaoDTO;
        }

        public async  Task<PromocaoDTO> Atualizar(int id, PromocaoDTO promocaoDTO)
        {
            if (!await _unitOfWork.Promocao.ExisteAsync(x => x.Id == id))
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(promocaoDTO.Id)));
                return null;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Promocao.AtualizarAsync(_mapper.Map<Promocao>(promocaoDTO));
            _unitOfWork.CommitTransaction();
            return promocaoDTO;
        }

        public async Task<bool> Remover(int id)
        {
            if (!await _unitOfWork.Promocao.ExisteAsync(x => x.Id == id))
            {
                Notificar(ValidationMessage.RegistroNaoExistente(nameof(id)));
                return false;
            }
            _unitOfWork.BeginTransaction();
            await _unitOfWork.Promocao.RemoverAsync(await _unitOfWork.Promocao.ObterPorId(id));
            _unitOfWork.CommitTransaction();
            return true;
        }

        public async Task<decimal> AplicarFormula(decimal valorProduto, int quantidadeProduto, int idFormula)
        {
            promocao = await ObterPorId(idFormula);
            if (promocao == null) return 0;
            qtdLeve =   !String.IsNullOrEmpty(promocao.Formula)? Convert.ToInt32(promocao.Formula.Replace("L", "").Split("P")[0]): 0 ;
            var valorPor =  !String.IsNullOrEmpty(promocao.Formula) ? 
                            promocao.Formula.Split("P")[1].Contains(",") ?
                                Convert.ToDecimal(promocao.Formula.Replace("L", "").Split("P")[1]) : Convert.ToInt32(promocao.Formula.Replace("L", "").Split("P")[1])
                            : 0;

            if (qtdLeve <= quantidadeProduto && valorPor > 0)
            {
                qtdPromocaoAplicada = promocao.Acumulativa ? (quantidadeProduto / qtdLeve) : 1;
                if (promocao.Formula.Split("P")[1].Contains(","))
                    return AplicarFormulaPorValor(valorProduto,  valorPor);
                else
                    return AplicarFormulaPorQuantidade(valorProduto,  (int)valorPor);
            }
            return 0;
        }
        
        #region MÉTODOS PRIVADOS
        private decimal AplicarFormulaPorValor(decimal valorProduto, decimal valorPor) =>
            ( qtdPromocaoAplicada * ((qtdLeve * valorProduto) - valorPor));

        private decimal AplicarFormulaPorQuantidade(decimal valorProduto, int valorPor)
        {
            var custoTotalPromo = qtdPromocaoAplicada * qtdLeve;
            var qtdDesconto = qtdPromocaoAplicada * valorPor;
            return (custoTotalPromo - qtdDesconto ) * valorProduto;
        }
        #endregion


    }
}
