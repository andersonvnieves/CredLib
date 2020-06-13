using CredLib.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CredLib.Domain.Tests.Entities
{
    public class CreditoPessoaJuridicaTest
    {
        private CreditoPessoaJuridica creditoConsignado = null;

        [Fact]
        public void CalcularJuros_DeveCalcularJurosComValorCorreto()
        {
            //Arrange
            creditoConsignado = new CreditoPessoaJuridica()
            {
                ValorDoCredito = 50000,
                QuantidadeDeParcelas = 24,
                DataPrimeiroVencimento = DateTime.Now.AddDays(20)
            };

            //Act
            creditoConsignado.CalcularJuros();

            //Assert
            Assert.Equal(2500, creditoConsignado.ValorDoJuros);
            Assert.Equal(52500, creditoConsignado.ValorDoCreditoComJuros);
        }

        [Fact]
        public void Validacao_DeveConfirmarValidacaoCorreta()
        {
            //Arrange
            creditoConsignado = new CreditoPessoaJuridica()
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
            creditoConsignado = new CreditoPessoaJuridica()
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
            creditoConsignado = new CreditoPessoaJuridica()
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
            creditoConsignado = new CreditoPessoaJuridica()
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
            creditoConsignado = new CreditoPessoaJuridica()
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
            creditoConsignado = new CreditoPessoaJuridica()
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

        [Fact]
        public void Validacao_DeveFalharValidacaoComValorDeCreditoMenor()
        {
            //Arrange
            creditoConsignado = new CreditoPessoaJuridica()
            {
                ValorDoCredito = 5000,
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
