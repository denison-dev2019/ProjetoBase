using Crosscutting.Enuns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public sealed class Pedido
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public EnumStatusPedido Status { get; set; }
        public int ClienteId { get; set; }
        public ICollection<PedidoItens> PedidoItens { get; set; }
     
    }
}

