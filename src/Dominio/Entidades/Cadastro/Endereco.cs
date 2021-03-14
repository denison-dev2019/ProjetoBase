using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Entidades
{
    public sealed class Endereco
    {
        [Key,MaxLength(7)]
        public string Cep { get; set; }
        [MaxLength(100)]
        public string Logradouro { get; set; }
        [MaxLength(100)]
        public string Complemento { get; set; }
        [MaxLength(100)]
        public string Localidade { get; set; }
        [MaxLength(2)]
        public string Uf { get; set; }
 
    }
}
