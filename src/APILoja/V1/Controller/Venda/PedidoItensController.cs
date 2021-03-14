using APILoja.Controllers.Base;
using Dominio.Interfaces.Servicos.Venda;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APILoja.V1.Controller.Venda
{
    [ApiVersion("1.0")]
    [Route("api/V{version:apiVersion}/vendas/pedidos-itens")]
    public class PedidoItensController : CustomController
    {
        private readonly IPedidoItensServico _pedidoItensServico;
        private readonly IPedidoFacadeServico _pedidoFacadeServico;
        public PedidoItensController(IServiceProvider serviceProvider,
            IPedidoItensServico pedidoItensServico, IPedidoFacadeServico pedidoFacadeServico) : base(serviceProvider)
        {
            _pedidoItensServico = pedidoItensServico;
            _pedidoFacadeServico = pedidoFacadeServico;
        }
        [HttpDelete("{idPedido}/{id}")]
        public async Task<ActionResult> Delete(int idPedido ,int id) => CustomResponse(await _pedidoFacadeServico.RemoverItem(idPedido,id));

       
    }
}
