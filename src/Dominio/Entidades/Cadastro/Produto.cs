using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public sealed class Produto
    {
        public int Id{ get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int PromocaoId { get; set; }
        
    }
}
