using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Base;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Cadastro
{
    
    public interface IPromocaoServico : IServicoBase<Promocao>
    {
        Task<PromocaoDTO> ObterPorId(int id);
        Task<List<PromocaoDTO>> ListarTodos();
        Task<PromocaoDTO> Adicionar(PromocaoDTO promocaoDTO);
        Task<PromocaoDTO> Atualizar(int id, PromocaoDTO promocaoDTO);
        Task<bool> Remover(int id);
        Task<decimal> AplicarFormula(decimal valorProduto, int quantidadeProduto, int idFormula);



        


    }
}
