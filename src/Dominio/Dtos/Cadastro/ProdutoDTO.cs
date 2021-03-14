using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Dtos.Cadastro
{
    public class ProdutoBaseDTO
    {
        public PromocaoDTO Promocao { get; set; }
    }
        public sealed class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int PromocaoId { get; set; }

    }

    public sealed class ProdutoGetDTO: ProdutoBaseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int PromocaoId { get; set; }
    }

    public sealed class ProdutoGetFiltroDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }




}
