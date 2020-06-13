using System;
using System.Collections.Generic;
using System.Text;

namespace CredLib.Domain.Common
{
    public abstract class Credito
    {       

        public float ValorDoCredito { get; set; }
        public float ValorDoCreditoComJuros { get; set; }
        public float ValorDoJuros { get; set; }
        public int QuantidadeDeParcelas { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }

        public abstract void CalcularJuros();
        public virtual bool Validacao()
        {
            var valido = true;

            if (ValorDoCredito > 1000000)
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
