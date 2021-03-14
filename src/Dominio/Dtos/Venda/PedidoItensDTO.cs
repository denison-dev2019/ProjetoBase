using Dominio.Dtos.Cadastro;

namespace Dominio.Dtos.Venda
{
    public class PedidoItensDTO
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeProduto { get; set; }
        public decimal ValorUnitarioProduto { get; set; }
        public decimal ValorTotalProduto => QuantidadeProduto * ValorUnitarioProduto;
        public decimal ValorDesconto { get; set; }
        public decimal ValorTotalComDesconto => ValorTotalProduto - ValorDesconto;
        public ProdutoGetDTO Produto { get; set; }
    }

    public class PedidoItensFiltroDTO
    {
        public int PedidoId { get; set; }
    }
}
