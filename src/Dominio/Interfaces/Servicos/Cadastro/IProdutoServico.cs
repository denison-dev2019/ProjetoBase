using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using Dominio.Interfaces.Servicos.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Servicos.Cadastro
{
    public interface IProdutoServico: IServicoBase<Produto>
    {
        Task<ProdutoDTO> Adicionar(ProdutoDTO produtoDTO);
        Task<ProdutoDTO> Atualizar(int id, ProdutoDTO produtoDTO);
        Task<bool> Remover(int id);
        Task<List<ProdutoGetDTO>> ListarTodos();
        Task<ProdutoGetDTO> ObterPorId(int id);
    }
}
