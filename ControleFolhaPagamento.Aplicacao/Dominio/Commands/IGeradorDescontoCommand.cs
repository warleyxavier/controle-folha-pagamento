using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands
{
    public interface IGeradorDescontoCommand
    {
        bool DeveGerar(Funcionario funcionario);
        Lancamento Gerar(Funcionario funcionario);
    }
}
