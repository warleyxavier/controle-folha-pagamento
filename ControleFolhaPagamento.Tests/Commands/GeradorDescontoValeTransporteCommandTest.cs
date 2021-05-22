using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using Xunit;

namespace ControleFolhaPagamento.Tests.Commands
{
    public class GeradorDescontoValeTransporteCommandTest
    {
        private readonly IGeradorDescontoCommand geradorDesconto;

        public GeradorDescontoValeTransporteCommandTest()
        {
            this.geradorDesconto = new GeradorDescontoValeTransporteCommand();
        }

        [Theory]
        [InlineData(true, 10.00, false)]
        [InlineData(true, 500.00, false)]
        [InlineData(true, 1000.00, false)]
        [InlineData(true, 1499.99, false)]
        [InlineData(true, 1500.00, true)]
        [InlineData(true, 2000.00, true)]
        [InlineData(false, 10.00, false)]
        [InlineData(false, 500.00, false)]
        [InlineData(false, 1000.00, false)]
        [InlineData(false, 1499.99, false)]
        [InlineData(false, 1500.00, false)]
        [InlineData(false, 2000.00, false)]
        public void DeveriaRetornarSePodeGerarComBaseNaConfiguracaoDoFuncionario(bool funcionarioPossuiValeTransporte, double salario, bool deveriaPoderGerarDesconto)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario,
                PossuiValeTransporte = funcionarioPossuiValeTransporte
            };

            bool podeGerarDesconto = this.geradorDesconto.DeveGerar(funcionario);

            Assert.Equal(deveriaPoderGerarDesconto, podeGerarDesconto);
        }

        [Theory]
        [InlineData(100, 6)]
        [InlineData(1000, 60)]
        [InlineData(150.80, 9.048)]
        public void DeveriaGerarDesconto(double salario, double descontoEsperado)
        {
            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            Lancamento desconto = this.geradorDesconto.Gerar(funcionario);

            Assert.Equal(TipoLancamento.Desconto, desconto.Tipo);
            Assert.Equal("Vale Transporte", desconto.Descricao);
            Assert.Equal(descontoEsperado, desconto.Valor);
        }
    }
}
