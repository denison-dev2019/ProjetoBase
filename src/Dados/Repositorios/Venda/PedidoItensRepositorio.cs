using Dados.Contextos;
using Dados.Repositorios.Base.Dados.Repositorios;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios.Base;
using Dominio.Interfaces.Repositorios.Venda;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Dados.Repositorios.Venda
{
    public class PedidoItensRepositorio: Repositorio<PedidoItens>, IPedidoItensRepositorio
    {
        public PedidoItensRepositorio(ProjetoBaseDbContext context): base(context){}
    }
}
