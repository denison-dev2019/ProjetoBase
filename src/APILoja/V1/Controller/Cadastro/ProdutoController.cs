using APILoja.Controllers.Base;
using Crosscutting.Enuns;
using Dominio.Dtos.Cadastro;
using Dominio.Interfaces.Servicos.Cadastro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APILoja.V1.Controller.Cadastro
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiversion}/cadastros/produtos")]
    public class ProdutoController : CustomController
    {
        private readonly IProdutoServico _produtoServico;
        public ProdutoController(IServiceProvider serviceProvider,
            IProdutoServico produtoServico) : base(serviceProvider)
        {
            _produtoServico = produtoServico;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Listar() 
        {
            var produtos = await _produtoServico.ListarTodos();
            return CustomResponse(produtos , produtos.Count > 0? EnumStatusResponseApi.Ok : EnumStatusResponseApi.NotFound);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> ListarPor(int id) 
        {
            var produto = await _produtoServico.ObterPorId(id);
            return CustomResponse(produto, produto != null ? EnumStatusResponseApi.Ok : EnumStatusResponseApi.NotFound);
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar([FromBody] ProdutoDTO produtoDTO)
        {
            var produto = await _produtoServico.Adicionar(produtoDTO);
            return CustomResponse(produto);
        }

        [HttpPut("{id}")]
        public async  Task<ActionResult<ProdutoDTO>> Atualizar(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            var produto = await _produtoServico.Atualizar(id,produtoDTO);
            return CustomResponse(produto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id) => CustomResponse(await _produtoServico.Remover(id));
    }
}
