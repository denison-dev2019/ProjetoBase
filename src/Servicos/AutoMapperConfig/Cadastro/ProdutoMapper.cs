using AutoMapper;
using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.AutoMapperConfig.Cadastro
{
    public class ProdutoMapper: Profile
    {
        public ProdutoMapper()
        {
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
            CreateMap<Produto, ProdutoGetDTO>().ReverseMap();
        }
    }
}
