using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Dominio.Entidades
{
 
    public sealed class PedidoItens
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorUnitarioProduto { get; set; }
        public decimal ValorTotalProduto => QuantidadeProduto * ValorUnitarioProduto;
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotalComDesconto => ValorTotalProduto - ValorDesconto;
        public Pedido Pedido { get; set; }
        public Produto Produto { get; set; }

    }
}
