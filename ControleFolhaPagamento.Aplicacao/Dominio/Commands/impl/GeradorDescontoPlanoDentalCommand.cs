using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoPlanoDentalCommand : IGeradorDescontoCommand
    {
        private const double VALOR_DESCONTO = 5.00;

        public bool DeveGerar(Funcionario funcionario)
        {
            return funcionario.PossuiPlanoDental;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            return new Lancamento(TipoLancamento.Desconto, VALOR_DESCONTO, "Plano Dental");
        }
    }
}
