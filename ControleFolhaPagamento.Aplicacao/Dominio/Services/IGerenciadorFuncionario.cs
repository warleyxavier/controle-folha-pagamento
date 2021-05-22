using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services
{
    public interface IGerenciadorFuncionario
    {
        public int inserir(Funcionario funcionario);
        public Funcionario pesquisar(int id);
    }
}
