using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.Utilitarios
{
    public static class ValidationMessage
    {
        public static string RegistroNaoEncontrado => "Registro não encontrado";
        public static string RegistroJaExistente(string campo) => $"{campo} já existe";
        public static string RegistroNaoExistente(string campo) => $"{campo} não existe";
        public static string NotNullGeneric => "O campo {PropertyName} precisa ser informado.";
        public static string LengthGeneric => "O campo {PropertyName} precisa ter {MaxLength} carecteres.";
        public static string MaxLengthGeneric => "O campo {PropertyName} precisa ter no máximo {MaxLength} carecteres.";
        public static string MinLengthGeneric => "O campo {PropertyName} precisa ter no mínimo {MinLength} carecteres.";
    }
}
