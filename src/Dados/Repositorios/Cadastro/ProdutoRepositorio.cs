using Dados.Contextos;
using Dados.Repositorios.Base.Dados.Repositorios;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Repositorios
{
    public class ProdutoRepositorio: Repositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(ProjetoBaseDbContext context) :base(context)
        {

        }
    }
}
