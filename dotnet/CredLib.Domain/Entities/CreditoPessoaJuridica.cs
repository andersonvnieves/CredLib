using CredLib.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace CredLib.Domain.Entities
{
    public class CreditoPessoaJuridica : Credito
    {
        public override void CalcularJuros()
        {
            const float _juros = 0.05F;

            this.ValorDoJuros = this.ValorDoCredito * _juros;
            this.ValorDoCreditoComJuros = this.ValorDoCredito + this.ValorDoJuros;
        }

        public override bool Validacao()
        {
            var valido = true;

            if (ValorDoCredito > 1000000 || ValorDoCredito < 15000)
                valido = false;

            if (QuantidadeDeParcelas > 72 || QuantidadeDeParcelas < 5)
                valido = false;

            if (DataPrimeiroVencimento < DateTime.Now.AddDays(15) ||
                DataPrimeiroVencimento > DateTime.Now.AddDays(40))
                valido = false;

            return valido;
        }
    }
}
