using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoFGTSCommand : IGeradorDescontoCommand
    {
        private const double PERCENTUAL_DESCONTO = 8.00;

        public bool DeveGerar(Funcionario funcionario)
        {
            return true;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            double valor = (funcionario.SalarioBruto / 100) * PERCENTUAL_DESCONTO;

            return new Lancamento(TipoLancamento.Desconto, valor, "FGTS");
        }
    }
}
