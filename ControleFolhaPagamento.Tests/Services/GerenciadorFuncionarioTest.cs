using System;
using Xunit;
using Moq;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using ControleFolhaPagamento.Aplicacao.Dominio.Services.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Tests.Services
{
    public class GerenciadorFuncionarioTest
    {
        private readonly Mock<IFuncionarioRepository> funcionarioRepository;
        private readonly Mock<IValidadorFuncionario> validadorFuncionario;

        private readonly IGerenciadorFuncionario gerenciador;

        public GerenciadorFuncionarioTest()
        {
            this.funcionarioRepository = new Mock<IFuncionarioRepository>();
            this.validadorFuncionario = new Mock<IValidadorFuncionario>();

            this.gerenciador = new GerenciadorFuncionario(funcionarioRepository.Object, validadorFuncionario.Object);
        }

        [Fact]
        public void DeveriaPesquisarFuncionarioPeloId()
        {
            const int ID = 7;
            var funcionario = new Funcionario() { Id = ID};

            this.funcionarioRepository.Setup(repository => repository.Pesquisar(ID)).Returns(funcionario);

            var funcionarioPesquisado = this.gerenciador.pesquisar(ID);

            Assert.Equal(funcionario, funcionarioPesquisado);
        }

        [Fact]
        public void DeveriaInserirFuncionario()
        {
            const string DOCUMENTO_INICIAL = "123.456.789-12";
            const string DOCUMENTO_FORMATADO = "12345678912";

            var funcionario = new Funcionario() { Documento = DOCUMENTO_INICIAL };
            var funcionarioInserido = new Funcionario() { Id = new Random().Next() };

            this.funcionarioRepository.Setup(repository => repository.Inserir(funcionario))
                .Returns(funcionarioInserido)
                .Callback<Funcionario>(funcionario =>
                {
                    Assert.Equal(DOCUMENTO_FORMATADO, funcionario.Documento);
                });

            int codigoDoFuncionarioInserido = this.gerenciador.inserir(funcionario);

            this.validadorFuncionario.Verify(validador => validador.Validar(funcionario), Times.Once());
            this.funcionarioRepository.Verify(repository => repository.Inserir(funcionario), Times.Once());

            Assert.Equal(funcionarioInserido.Id, codigoDoFuncionarioInserido);
        }
    }
}
