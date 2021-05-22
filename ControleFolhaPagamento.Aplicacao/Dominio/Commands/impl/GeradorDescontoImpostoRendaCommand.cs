using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoImpostoRendaCommand : IGeradorDescontoCommand
    {
        public bool DeveGerar(Funcionario funcionario)
        {
            const double MENOR_VALOR_PARA_CALCULO = 1903.98;

            return funcionario.SalarioBruto > MENOR_VALOR_PARA_CALCULO;
        }

        public Lancamento Gerar(Funcionario funcionario)
        {
            double percentual = GerarPercentualParaCalculo(funcionario.SalarioBruto);
            double valor = (funcionario.SalarioBruto / 100) * percentual;

            valor = ReduzirValorAoTetoSeNecessario(funcionario.SalarioBruto, valor);

            return new Lancamento(TipoLancamento.Desconto, valor, "Imposto de Renda (IR)");
        }

        private double GerarPercentualParaCalculo(double salario)
        {
            if (salario <= 2826.65)
                return 7.5;

            if (salario <= 3751.05)
                return 15;

            if (salario <= 4664.68)
                return 22.5;

            return 27.5;
        }

        private double ReduzirValorAoTetoSeNecessario(double salario, double valor)
        {
            if (salario <= 2826.65)
                return valor > 142.80 ? 142.80 : valor;

            if (salario <= 3751.05)
                return valor > 354.80 ? 354.80 : valor;

            if (salario <= 4664.68)
                return valor > 636.13 ? 636.13 : valor;

            return valor > 869.36 ? 869.36 : valor;
        }
    }
}
