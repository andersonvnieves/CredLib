using CredLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CredLib.Domain.Tests.Entities
{
    public class CreditoImobiliarioTest
    {
        private CreditoImobiliario creditoConsignado = null;

        [Fact]
        public void CalcularJuros_DeveCalcularJurosComValorCorreto()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50000,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            creditoConsignado.CalcularJuros();

            //Assert
            Assert.Equal(4500, creditoConsignado.ValorDoJuros);
            Assert.Equal(54500, creditoConsignado.ValorDoCreditoComJuros);
        }

        [Fact]
        public void Validacao_DeveConfirmarValidacaoCorreta()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50580,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.True(statusValidacao);
        }

        [Fact]
        public void Validacao_DeveFalharValidacaoComDataVencimentoMenor()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50580,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(5)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.False(statusValidacao);
        }

        [Fact]
        public void Validacao_DeveFalharValidacaoComDataVencimentoMaior()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50580,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(50)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.False(statusValidacao);
        }

        [Fact]
        public void Validacao_DeveFalharValidacaoComNumeroDeParcelasMaior()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50580,
                QuantidadeDeParcelas = 80,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.False(statusValidacao);
        }

        [Fact]
        public void Validacao_DeveFalharValidacaoComNumeroDeParcelasMenor()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50580,
                QuantidadeDeParcelas = 2,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.False(statusValidacao);
        }

        [Fact]
        public void Validacao_DeveFalharValidacaoComValorDeCreditoMaior()
        {
            //Arrange
            creditoConsignado = new CreditoImobiliario()
            {
                ValorDoCredito = 50000000,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            var statusValidacao = creditoConsignado.Validacao();

            //Assert
            Assert.False(statusValidacao);
        }
    }
}
