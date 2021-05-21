using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores.impl;
using System.Linq;

namespace ControleFolhaPagamento.Tests.Validadores
{
    public class ValidadorFuncionarioTest
    {
        private readonly IValidadorFuncionario validador;

        public ValidadorFuncionarioTest()
        {
            this.validador = new ValidadorFuncionario();
        }

        [Fact]
        public void DeveriaLancarExcecaoCasoFuncionarioEstejaInvalido()
        {
            var funcionario = new Funcionario();
            var falhasEsperadas = new string[]
            {
                "Nome não foi informado",
                "Sobre Nome não foi informado",
                "Setor não foi informado",
                "Documento não foi informado",
                "Salario Bruto não foi informado",
            };

            ValidarLancamentoExcecaoAoValidarFuncionario(funcionario, falhasEsperadas);
        }

        [Theory]
        [InlineData("123")]
        [InlineData("123456")]
        [InlineData("123456789")]
        [InlineData("1234567890")]
        [InlineData("123456789011")]
        [InlineData("1.2.3.4.5.6.7.8.9.0.1")]
        public void DeveriaLancarExcecaoCasoDocumentoFuncionarioEstejaInvalido(string documento)
        {
            var funcionario = new Funcionario() { Documento = documento };
            var falhasEsperadas = new string[]
            {
                "O Documento informado é inválido",
            };

            ValidarLancamentoExcecaoAoValidarFuncionario(funcionario, falhasEsperadas);
        }

        private void ValidarLancamentoExcecaoAoValidarFuncionario(Funcionario funcionario, string[] falhasEsperadas)
        {
            var exception = Assert.Throws<ValidacaoException>(() =>
            {
                validador.Validar(funcionario);
            });

            foreach (var falha in falhasEsperadas)
            {
                Assert.True(exception.Erros.Contains(falha));
            }
        }

        [Fact]
        public void NaoDeveriaLancarExcecaoSeFuncionarioEstiverCorreto()
        {
            var funcionario = ConstruirFuncionarioComDadosValidos();
            this.validador.Validar(funcionario);
            Assert.True(true);
        }

        private Funcionario ConstruirFuncionarioComDadosValidos()
        {
            return new Funcionario()
            {
                Nome = "Warley",
                SobreNome = "Andrade Xavier",
                Documento = "94358937080",
                Setor = "TI",
                SalarioBruto = 50000.01
            };
        }
    }
}
