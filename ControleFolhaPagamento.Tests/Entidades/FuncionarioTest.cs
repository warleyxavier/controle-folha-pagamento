using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Tests.Entidades
{
    public class FuncionarioTest
    {
        private readonly Funcionario funcionario;

        public FuncionarioTest()
        {
            this.funcionario = new Funcionario();
        }

        [Theory]
        [InlineData("12345678", "12345678")]
        [InlineData("539.121.650-84", "53912165084")]
        [InlineData("539.121.65084", "53912165084")]
        [InlineData("539121650-84", "53912165084")]
        [InlineData("53912165084", "53912165084")]
        [InlineData("", "")]
        public void DeveriaRemoverCaracteresDoDocumentoDoFuncionario(string documento, string documentoEsperado)
        {
            funcionario.Documento = documento;
            funcionario.RemoverCaracteresDoDocumento();
            Assert.Equal(documentoEsperado, funcionario.Documento);
        }

    }
}
