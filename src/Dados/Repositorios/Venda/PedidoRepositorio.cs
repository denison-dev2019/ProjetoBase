using Dados.Contextos;
using Dados.Repositorios.Base.Dados.Repositorios;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorios
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(ProjetoBaseDbContext context): base(context)
        {
        }

        public override async Task<Pedido> AtualizarAsync(Pedido pedido) 
        {
            _db.Set<PedidoItens>().RemoveRange(
                await _db.Set<PedidoItens>().Where(x=>x.PedidoId == pedido.Id).ToArrayAsync());

            return await base.AtualizarAsync(pedido);
        }

    }
}
