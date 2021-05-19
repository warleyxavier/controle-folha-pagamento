using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services
{
    public interface IGerenciadorFuncionario
    {
        public int inserir(Funcionario funcionario);
        public Funcionario pesquisar(int id);
    }
}
