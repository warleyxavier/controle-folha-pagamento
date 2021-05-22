using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoINSSCommand : IGeradorDescontoCommand
    {
        public bool DeveGerar(Funcionario funcionario)
        {
            return true;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            double percentual = GerarPercentualParaCalculo(funcionario.SalarioBruto);
            double valor = (funcionario.SalarioBruto / 100) * percentual;

            return new Lancamento(TipoLancamento.Desconto, valor, "INSS");
        }

        private double GerarPercentualParaCalculo(double salario)
        {
            if (salario <= 1045)
                return 7.5;

            if (salario <= 2089.60)
                return 9;

            if (salario <= 3134.40)
                return 12;

            return 14;
        }
    }
}
