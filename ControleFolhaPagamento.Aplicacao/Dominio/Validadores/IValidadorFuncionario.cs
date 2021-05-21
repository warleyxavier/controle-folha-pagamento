using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Validadores
{
    public interface IValidadorFuncionario
    {
        void Validar(Funcionario funcionario);
    }
}
