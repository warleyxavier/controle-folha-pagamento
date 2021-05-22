using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories
{
    public interface IFuncionarioRepository
    {
        Funcionario Inserir(Funcionario funcionario);
        Funcionario Pesquisar(int id);
    }
}
