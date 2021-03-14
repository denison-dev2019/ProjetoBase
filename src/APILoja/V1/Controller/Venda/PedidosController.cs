using APILoja.Controllers.Base;
using Crosscutting.Enuns;
using Dominio.Dtos;
using Dominio.Dtos.Venda;
using Dominio.Interfaces.Servicos.Venda;
using Microsoft.AspNetCore.Mvc;
using Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace APILoja.V1.Controller
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiVersion}/vendas/pedidos")]
    public class PedidosController : CustomController
    {
        private readonly IPedidoFacadeServico _pedidoFacadeServico;
        private readonly IPedidoServico _pedidoServico;
        public PedidosController(IServiceProvider serviceProvider,
            IPedidoFacadeServico pedidoFacadeServico,
            IPedidoServico pedidoServico) : base(serviceProvider)
        {
            _pedidoFacadeServico = pedidoFacadeServico;
            _pedidoServico = pedidoServico;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoDTO>>> Listar()
        {
            var pedidos = await _pedidoServico.ListarTodos();
            return CustomResponse(pedidos, pedidos != null ? EnumStatusResponseApi.Ok : EnumStatusResponseApi.NotFound);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoGetDTO>> ListarPorId(int id)
        {
            var pedido = await _pedidoFacadeServico.ObterPorId(id);
            return CustomResponse(pedido, pedido != null ? EnumStatusResponseApi.Ok : EnumStatusResponseApi.NotFound);
        }

        [HttpPost, Route("adicionar")]
        public async Task<ActionResult<PedidoDTO>> Adicionar([FromBody] PedidoDTO pedidoDTO) => 
            CustomResponse(await _pedidoServico.Adicionar(pedidoDTO));

        [HttpPut("atualizar/{id}")]
        public async Task<ActionResult<PedidoDTO>> Atualizar([FromBody] PedidoDTO pedidoDTO) => 
            CustomResponse(await _pedidoFacadeServico.Atualizar(pedidoDTO));

        [HttpDelete, Route("excluir/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id) => CustomResponse(await _pedidoFacadeServico.Remover(id));
    }
}
