using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Tests.Commands
{
    public class GeradorDescontoINSSCommandTest
    {
        private readonly IGeradorDescontoCommand geradorDesconto;

        public GeradorDescontoINSSCommandTest()
        {
            this.geradorDesconto = new GeradorDescontoINSSCommand();
        }

        [Fact]
        public void SempreDeveriaRetornarQuePodeCalcularINSS()
        {
            bool podeGerarDesconto = this.geradorDesconto.DeveGerar(new Funcionario());
            Assert.True(podeGerarDesconto);
        }

        [Theory]
        [InlineData(100, 7.5)]
        [InlineData(1000, 75.00)]
        [InlineData(1524.89, 137.2401)]
        [InlineData(2344.10, 281.292)]
        [InlineData(4500.25, 630.035)]
        [InlineData(7380.50, 1033.27)]
        public void DeveriaGerarDesconto(double salario, double descontoEsperado)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            Lancamento desconto = this.geradorDesconto.Gerar(funcionario);

            Assert.Equal(TipoLancamento.Desconto, desconto.Tipo);
            Assert.Equal("INSS", desconto.Descricao);
            Assert.Equal(descontoEsperado, desconto.Valor);
        }
    }
}
