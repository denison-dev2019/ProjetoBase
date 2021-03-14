using Crosscutting.Enuns;
using Dominio.Dtos.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Dtos.Venda
{
    public class PedidoDTO
    {       
            public int Id { get; set; }
            public decimal Valor { get; set; }
            public EnumStatusPedido Status { get; set; }
            public int ClienteId { get; set; }
            public IEnumerable<PedidoItensDTO> PedidoItens { get; set; }
    }

    public class PedidoGetDTO
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public EnumStatusPedido Status { get; set; }
        public EnumFormaPagamento FormaPagamento{ get; set; }
        public ClienteDTO Cliente { get; set; }
        public IEnumerable<PedidoItensDTO> PedidoItens { get; set; }
    }

}
