using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Validadores
{
    public interface IValidadorFuncionario
    {
        void Validar(Funcionario funcionario);
    }
}
