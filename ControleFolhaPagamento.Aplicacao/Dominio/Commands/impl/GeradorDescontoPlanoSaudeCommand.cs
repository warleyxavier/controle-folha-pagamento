using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoPlanoSaudeCommand : IGeradorDescontoCommand
    {
        private const double VALOR_DESCONTO = 10.00;

        public bool DeveGerar(Funcionario funcionario)
        {
            return funcionario.PossuiPlanoSaude;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            return new Lancamento(TipoLancamento.Desconto, VALOR_DESCONTO, "Plano de Saúde");
        }
    }
}
