using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dominio.Dtos.Cadastro
{
    /*public sealed class PromocaoGetDTO: PromocaoDTO
    {
        public int Id { get; set; }
    }*/

    public  class PromocaoDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Formula { get; set; }
        public bool Acumulativa { get; set; }
    }
}
