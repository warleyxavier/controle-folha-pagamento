using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using Xunit;

namespace ControleFolhaPagamento.Tests.Commands
{
    public class GeradorDescontoImpostoRendaCommandTest
    {
        private readonly IGeradorDescontoCommand geradorDesconto;

        public GeradorDescontoImpostoRendaCommandTest()
        {
            this.geradorDesconto = new GeradorDescontoImpostoRendaCommand();
        }

        [Theory]
        [InlineData(100, false)]
        [InlineData(1000, false)]
        [InlineData(1900, false)]
        [InlineData(2000, true)]
        [InlineData(4000, true)]
        [InlineData(6000, true)]
        [InlineData(100000, true)]
        public void DeveriaRetornarQuePodeCalcularDescontoSeSalarioForMaiorQueMinimo(double salario, bool deveriaPoderCalcularDesconto)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            bool podeCalcularDesconto = this.geradorDesconto.DeveGerar(funcionario);

            Assert.Equal(deveriaPoderCalcularDesconto, podeCalcularDesconto);
        }

        [Theory]
        [InlineData(2000.00, 142.80)]
        [InlineData(1903.99, 142.79925)]
        [InlineData(3100.50, 354.80)]
        [InlineData(2826.66, 354.80)]
        [InlineData(4500.25, 636.13)]
        [InlineData(3751.06, 636.13)]
        [InlineData(4664.69, 869.36)]
        [InlineData(8521.25, 869.36)]
        public void DeveriaGerarDesconto(double salario, double descontoEsperado)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            Lancamento desconto = this.geradorDesconto.Gerar(funcionario);

            Assert.Equal(TipoLancamento.Desconto, desconto.Tipo);
            Assert.Equal("Imposto de Renda (IR)", desconto.Descricao);
            Assert.Equal(descontoEsperado, desconto.Valor);
        }
    }
}
