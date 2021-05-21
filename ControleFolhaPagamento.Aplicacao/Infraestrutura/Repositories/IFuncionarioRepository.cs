using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;

namespace ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories
{
    public interface IFuncionarioRepository
    {
        Funcionario Inserir(Funcionario funcionario);
        Funcionario Pesquisar(int id);
    }
}
