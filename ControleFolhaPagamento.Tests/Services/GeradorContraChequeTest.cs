using System.Collections.Generic;
using Xunit;
using Moq;
using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Dominio.Services.impl;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;

namespace ControleFolhaPagamento.Tests.Services
{
    public class GeradorContraChequeTest
    {
        private readonly Mock<IFuncionarioRepository> funcionarioRepository;
        private readonly Mock<IGeradorDescontoFactory> geradorDescontosFactory;
        private readonly Mock<IGeradorDescontoCommand> geradorDesconto;

        private readonly IGeradorContraCheque geradorContraCheque;

        public GeradorContraChequeTest()
        {
            this.funcionarioRepository = new Mock<IFuncionarioRepository>();
            this.geradorDescontosFactory = new Mock<IGeradorDescontoFactory>();


            geradorDesconto = new Mock<IGeradorDescontoCommand>();
            
            IList<IGeradorDescontoCommand> geradoresDesconto = new List<IGeradorDescontoCommand>()
            {
                geradorDesconto.Object
            };

            this.geradorDescontosFactory.Setup(factory => factory.Gerar()).Returns(geradoresDesconto);

            this.geradorContraCheque = new GeradorContraCheque(funcionarioRepository.Object, geradorDescontosFactory.Object);
        }

        [Fact]
        public void DeveriaLancarExcecaoSeNaoEncontrarFuncionario()
        {
            const int ID = 9;

            this.funcionarioRepository.Setup(repository => repository.Pesquisar(ID)).Returns((Funcionario)null);

            var exception = Assert.Throws<EBaseException>(() => this.geradorContraCheque.Gerar(ID));

            Assert.Equal(404, exception.StatusCode);
            Assert.Equal("Funcionário não encontrado", exception.Message);
        }

        [Fact]
        public void DeveriaGerarContraCheque()
        {
            const int ID = 19;

            geradorDesconto.Setup(gerador => gerador.DeveGerar(It.IsAny<Funcionario>())).Returns(true);
            geradorDesconto.Setup(gerador => gerador.Gerar(It.IsAny<Funcionario>())).Returns(new Lancamento(TipoLancamento.Desconto, 10, string.Empty));

            var funcionario = new Funcionario()
            {
                SalarioBruto = 10
            };

            this.funcionarioRepository.Setup(repository => repository.Pesquisar(ID)).Returns(funcionario);

            var contraCheque = this.geradorContraCheque.Gerar(ID);

            Assert.Equal(funcionario.SalarioBruto, contraCheque.SalarioBruto);
            Assert.Equal(2, contraCheque.Lancamentos.Count);

            geradorDesconto.Verify(gerador => gerador.DeveGerar(funcionario), Times.Once());
            geradorDesconto.Verify(gerador => gerador.Gerar(funcionario), Times.Once());
        }
    }
}
