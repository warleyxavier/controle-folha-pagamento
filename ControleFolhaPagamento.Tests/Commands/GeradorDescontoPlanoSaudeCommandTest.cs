using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;

namespace ControleFolhaPagamento.Tests.Commands
{
    public class GeradorDescontoPlanoSaudeCommandTest
    {
        private readonly IGeradorDescontoCommand geradorDesconto;

        public GeradorDescontoPlanoSaudeCommandTest()
        {
            this.geradorDesconto = new GeradorDescontoPlanoSaudeCommand();
        }

        [Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void DeveriaRetornarSePodeGerarComBaseNaConfiguracaoDoFuncionario(bool funcionarioPossuiPlanoSaude, bool deveriaPoderGerarDesconto)
        {
            var funcionario = new Funcionario()
            {
                PossuiPlanoSaude = funcionarioPossuiPlanoSaude
            };

            bool podeGerarDesconto = this.geradorDesconto.DeveGerar(funcionario);

            Assert.Equal(deveriaPoderGerarDesconto, podeGerarDesconto);
        }

        [Theory]
        [InlineData(100)]
        [InlineData(1000)]
        [InlineData(150.80)]
        public void DeveriaGerarDesconto(float salario)
        {
            const double VALOR_DE_DESCONTO_ESPERADO = 10.00;

            var funcionario = new Funcionario()
            {
                SalarioBruto = salario
            };

            Lancamento desconto = this.geradorDesconto.Gerar(funcionario);

            Assert.Equal(TipoLancamento.Desconto, desconto.Tipo);
            Assert.Equal("Plano de Saúde", desconto.Descricao);
            Assert.Equal(VALOR_DE_DESCONTO_ESPERADO, desconto.Valor);
        }
    }
}
