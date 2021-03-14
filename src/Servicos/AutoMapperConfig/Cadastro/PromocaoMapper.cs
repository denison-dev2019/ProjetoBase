using AutoMapper;
using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.AutoMapperConfig.Cadastro
{
    public class PromocaoMapper: Profile
    {
        public PromocaoMapper()
        {
            CreateMap<Promocao, PromocaoDTO>().ReverseMap();
            //CreateMap<Promocao, PromocaoGetDTO>().ReverseMap();
        }
    }
}
