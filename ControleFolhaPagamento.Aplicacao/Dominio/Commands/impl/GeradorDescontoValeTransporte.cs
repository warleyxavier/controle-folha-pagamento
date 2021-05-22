using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoValeTransporte : IGeradorDescontoCommand
    {
        private const double PERCENTUAL_DESCONTO = 6.00;

        public bool DeveGerar(Funcionario funcionario)
        {
            const double MENOR_SALARIO_PARA_CALCULO = 1500;

            return funcionario.PossuiValeTransporte && funcionario.SalarioBruto > MENOR_SALARIO_PARA_CALCULO;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            double valor = (funcionario.SalarioBruto / 100) * PERCENTUAL_DESCONTO;

            return new Lancamento(TipoLancamento.Desconto, valor, "Vale Transporte");
        }
    }
}
