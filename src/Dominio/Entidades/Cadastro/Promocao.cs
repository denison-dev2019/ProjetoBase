using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public sealed class Promocao
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Descricao { get; set; }
        [MaxLength(50)]
        public string Formula { get; set; }
        public bool Acumulativa { get; set; }
    }
}
