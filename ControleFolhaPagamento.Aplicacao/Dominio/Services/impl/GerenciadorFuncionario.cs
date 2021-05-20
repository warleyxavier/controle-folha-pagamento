using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services.impl
{
    public class GerenciadorFuncionario : IGerenciadorFuncionario
    {
        private readonly IFuncionarioRepository repository;

        public GerenciadorFuncionario(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }

        public int inserir(Funcionario funcionario)
        {
            Funcionario funcionarioInserido = this.repository.Inserir(funcionario);
            return funcionarioInserido.Id;
        }

        public Funcionario pesquisar(int id)
        {
            return this.repository.Pesquisar(id);
        }
    }
}
