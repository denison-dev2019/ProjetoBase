using AutoMapper;
using Dominio.Dtos.Cadastro;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.AutoMapperConfig.Cadastro
{
    public class ClienteMapper: Profile
    {
        public ClienteMapper()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
        }
    }
}
