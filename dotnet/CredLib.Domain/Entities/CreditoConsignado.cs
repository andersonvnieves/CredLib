using CredLib.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CredLib.Domain.Entities
{
    public class CreditoConsignado : Credito
    {
        public override void CalcularJuros()
        {
            const float _juros = 0.01F;

            this.ValorDoJuros = this.ValorDoCredito * _juros;
            this.ValorDoCreditoComJuros = this.ValorDoCredito + this.ValorDoJuros;
        }
    }
}
