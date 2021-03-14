using APILoja.Controllers.Base;
using Crosscutting.Enuns;
using Dominio.Dtos.Cadastro;
using Dominio.Interfaces.Servicos.Cadastro;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APILoja.V1.Controller.Cadastro
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiversion}/cadastros/promocoes")]
    public class PromocaoController : CustomController
    {
        private readonly IPromocaoServico _promocaoServico;
        public PromocaoController(IServiceProvider serviceProvider,
            IPromocaoServico promocaoServico) : base(serviceProvider)
        {
            _promocaoServico = promocaoServico;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PromocaoDTO>>> Listar()
        {
            var promocoes = await _promocaoServico.ListarTodos();
            return CustomResponse(promocoes, promocoes.Count == 0 ? EnumStatusResponseApi.NotFound : EnumStatusResponseApi.Ok);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PromocaoDTO>> ListarPorId(int id)
        {
            var promocao = await _promocaoServico.ObterPorId(id);
            return CustomResponse(promocao, promocao ==null? EnumStatusResponseApi.NotFound: EnumStatusResponseApi.Ok);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar([FromBody] PromocaoDTO promocaoDTO) => 
            CustomResponse(await _promocaoServico.Adicionar(promocaoDTO));

        [HttpPut("{id}")]
        public async Task<ActionResult<PromocaoDTO>> Atualizar(int id, [FromBody] PromocaoDTO promocaoDTO) => 
            CustomResponse(await _promocaoServico.Atualizar(id, promocaoDTO));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id) => CustomResponse(await _promocaoServico.Remover(id));
    }
}
