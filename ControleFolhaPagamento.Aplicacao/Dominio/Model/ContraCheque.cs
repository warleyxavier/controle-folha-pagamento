using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using System;
using System.Collections.Generic;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Model
{
    public class ContraCheque
    {
        public ContraCheque(double salarioBruto)
        {
            Mes = DateTime.Now.ToString("MMMM");
            SalarioBruto = salarioBruto;
            SalarioLiquido = SalarioBruto;
            TotalDescontos = 0;
            Lancamentos = new List<Lancamento>();

            this.AdicionarRemuneracao(SalarioBruto);
        }

        public string Mes { get; private set; }
        public double SalarioBruto { get; private set; }
        public double TotalDescontos { get; private set; }
        public double SalarioLiquido { get; private set; }
        public IList<Lancamento> Lancamentos { get; private set; }

        private void AdicionarRemuneracao(double valor)
        {
            this.Lancamentos.Add(new Lancamento(TipoLancamento.Remuneracao, valor, "Remuneração"));
        }

        public void AdicionarDesconto(Lancamento desconto)
        {
            this.Lancamentos.Add(desconto);

            this.SalarioLiquido -= desconto.Valor;
            this.TotalDescontos -= desconto.Valor;
        }
    }
}
