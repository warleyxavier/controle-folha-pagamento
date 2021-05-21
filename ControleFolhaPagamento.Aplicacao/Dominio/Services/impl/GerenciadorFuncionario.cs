using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services.impl
{
    public class GerenciadorFuncionario : IGerenciadorFuncionario
    {
        private readonly IFuncionarioRepository repository;
        private readonly IValidadorFuncionario validadorFuncionario;

        public GerenciadorFuncionario(IFuncionarioRepository repository, IValidadorFuncionario validadorFuncionario)
        {
            this.repository = repository;
            this.validadorFuncionario = validadorFuncionario;
        }

        public int inserir(Funcionario funcionario)
        {
            this.validadorFuncionario.Validar(funcionario);
            funcionario.RemoverCaracteresDoDocumento();
            Funcionario funcionarioInserido = this.repository.Inserir(funcionario);
            return funcionarioInserido.Id;
        }

        public Funcionario pesquisar(int id)
        {
            return this.repository.Pesquisar(id);
        }
    }
}
