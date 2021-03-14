using AutoMapper;
using Dominio.Dtos;
using Dominio.Dtos.Cadastro;
using Dominio.Dtos.Venda;
using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servicos.AutoMapperConfig
{
    public class PedidoMapper: Profile
    {
        public PedidoMapper()
        {
            CreateMap<Pedido, PedidoDTO>().ReverseMap();
            CreateMap<PedidoItens, PedidoItensDTO>().ReverseMap();
            CreateMap<PedidoDTO, PedidoGetDTO>().ReverseMap();
        }
    }
}
