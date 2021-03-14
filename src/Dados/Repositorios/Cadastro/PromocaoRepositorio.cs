using Dados.Contextos;
using Dados.Repositorios.Base.Dados.Repositorios;
using Dominio.Entidades;
using Dominio.Interfaces.Repositorios.Cadastro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dados.Repositorios.Cadastro
{
    public class PromocaoRepositorio: Repositorio<Promocao>, IPromocaoRepositorio
    {
        public PromocaoRepositorio(ProjetoBaseDbContext context) : base(context)
        {

        }
    }
}
