using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;

namespace ControleFolhaPagamento.Tests.Commands
{
    public class GeradorDescontoFGTSCommandTest
    {
        private readonly IGeradorDescontoCommand geradorDesconto;

        public GeradorDescontoFGTSCommandTest()
        {
            this.geradorDesconto = new GeradorDescontoFGTSCommand();
        }

        [Fact]
        public void SempreDeveriaPoderGerarDesconto()
        {
            Assert.True(geradorDesconto.DeveGerar(new Funcionario()));
        }

        [Theory]
        [InlineData(100,8)]
        [InlineData(1000,80)]
        [InlineData(150.80,12.064)]
        public void DeveriaGerarDesconto(double salario, double descontoEsperado)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            Lancamento desconto = this.geradorDesconto.Gerar(funcionario);

            Assert.Equal(TipoLancamento.Desconto, desconto.Tipo);
            Assert.Equal("FGTS", desconto.Descricao);
            Assert.Equal(descontoEsperado, desconto.Valor);
        }
    }
}
