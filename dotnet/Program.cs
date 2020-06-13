using CredLib.Domain.Common;
using CredLib.Domain.Entities;
using CredLib.Domain.Enumerations;
using System;
using System.Net;
using System.Runtime.CompilerServices;

namespace CredLib.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==============================================================");
            Console.WriteLine("Liberação de Crédito");
            Console.WriteLine("==============================================================\n");
                       
            Console.WriteLine("\nSIMULAÇÃO 1 ==================================================\n");
            SimulacaoLiberacaoCredito(TiposDeCredito.CreditoDireto, 18000, 12, DateTime.Now.AddDays(5));

            Console.WriteLine("\nSIMULAÇÃO 2 ==================================================\n");
            SimulacaoLiberacaoCredito(TiposDeCredito.CreditoConsignado, 18000, 24, DateTime.Now.AddDays(20));

            Console.WriteLine("\nSIMULAÇÃO 3 ==================================================\n");
            SimulacaoLiberacaoCredito(TiposDeCredito.CreditoPessoaFisica, 18000, 18, DateTime.Now.AddDays(23));

            Console.WriteLine("\nSIMULAÇÃO 4 ==================================================\n");
            SimulacaoLiberacaoCredito(TiposDeCredito.CreditoImobiliario, 18000, 8, DateTime.Now.AddDays(19));

            Console.WriteLine("\nSIMULAÇÃO 5 ==================================================\n");
            SimulacaoLiberacaoCredito(TiposDeCredito.CreditoPessoaJuridica, 18000, 12, DateTime.Now.AddDays(20));
        }


        public static void SimulacaoLiberacaoCredito(TiposDeCredito tipoCredito, float valorCredito, int quantidadeParcela, DateTime dataVencimentoParcela)
        {
            Credito credito = null;

            switch (tipoCredito)
            {
                case TiposDeCredito.CreditoDireto:
                    credito = new CreditoDireto();
                    break;
                case TiposDeCredito.CreditoConsignado:
                    credito = new CreditoConsignado();
                    break;
                case TiposDeCredito.CreditoPessoaJuridica:
                    credito = new CreditoPessoaJuridica();
                    break;
                case TiposDeCredito.CreditoPessoaFisica:
                    credito = new CreditoPessoaFisica();
                    break;
                case TiposDeCredito.CreditoImobiliario:
                    credito = new CreditoImobiliario();
                    break;
            }

            credito.ValorDoCredito = valorCredito;
            credito.QuantidadeDeParcelas = quantidadeParcela;
            credito.DataPrimeiroVencimento = dataVencimentoParcela;

            ExibeEntrada(credito, tipoCredito);

            credito.CalcularJuros();
            var statusAprovacao = credito.Validacao();
            ExibeResultado(credito, statusAprovacao);
          
        }

        public static void ExibeEntrada(Credito credito, TiposDeCredito tipoCredito)
        {            
            Console.WriteLine("ENTRADA ======================================================");
            Console.WriteLine($"Valor de Crédito: R${credito.ValorDoCredito}");
            Console.WriteLine($"Tipo De Crédito: {tipoCredito}");
            Console.WriteLine($"Quantidade de Parcelas: {credito.QuantidadeDeParcelas}");
            Console.WriteLine($"Data do Primeiro Vencimento: {credito.DataPrimeiroVencimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine("==============================================================");
        }

        public static void ExibeResultado(Credito credito, bool statusAprovacao)
        {            
            Console.WriteLine("RESULTADO ====================================================");
            Console.WriteLine($"Status do Crédito: {(statusAprovacao ? "APROVADO" : "RECUSADO")}");
            Console.WriteLine($"Valor total com juros: R${credito.ValorDoCreditoComJuros}");
            Console.WriteLine($"Valor do juros: R${credito.ValorDoJuros}");
            Console.WriteLine("==============================================================");
        }
    }
}
