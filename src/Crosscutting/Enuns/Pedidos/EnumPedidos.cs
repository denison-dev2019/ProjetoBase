using System;
using System.Collections.Generic;
using System.Text;

namespace Crosscutting.Enuns
{
    public enum EnumStatusPedido
    {
        Aberto = 0,
        Cancelado = 1,
        Finalizado = 2
    }

    public enum EnumFormaPagamento
    {
        VisaDebito = 0,
        VisaCredito = 1,
        MasterDebito = 2,
        MasterCredito = 3,
        Boleto = 4,
    }
}
