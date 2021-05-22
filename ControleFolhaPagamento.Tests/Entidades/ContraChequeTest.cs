using System;
using Xunit;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using System.Linq;
using ControleFolhaPagamento.Aplicacao.Dominio.Enums;

namespace ControleFolhaPagamento.Tests.Entidades
{
    public class ContraChequeTest
    {
        [Fact]
        public void DeveriaInicializarObjetoCorretamente()
        {
            const double SALARIO_BRUTO = 10.50;

            var contraCheque = new ContraCheque(SALARIO_BRUTO);

            Assert.Equal(DateTime.Now.ToString("MMMM"), contraCheque.Mes);
            Assert.Equal(SALARIO_BRUTO, contraCheque.SalarioBruto);
            Assert.Equal(SALARIO_BRUTO, contraCheque.SalarioLiquido);
            Assert.Equal(0.00, contraCheque.TotalDescontos);

            Assert.NotNull(contraCheque.Lancamentos);

            var lancamento = contraCheque.Lancamentos.First();

            Assert.Equal(TipoLancamento.Remuneracao, lancamento.Tipo);
            Assert.Equal(SALARIO_BRUTO, lancamento.Valor);
            Assert.Equal("Remuneração", lancamento.Descricao);
        }

        [Fact]
        public void DeveriaAdicionarDescontoCorretamente()
        {
            const double SALARIO_BRUTO = 100;
            const double SALARIO_LIQUIDO_ESPERADO = 67.45;
            const double TOTAL_DESCONTOS_ESPERADO = -32.55;

            var contraCheque = new ContraCheque(SALARIO_BRUTO);

            contraCheque.AdicionarDesconto(new Lancamento(TipoLancamento.Desconto, 15.00, String.Empty));
            contraCheque.AdicionarDesconto(new Lancamento(TipoLancamento.Desconto, 10.00, String.Empty));
            contraCheque.AdicionarDesconto(new Lancamento(TipoLancamento.Desconto, 7.55, String.Empty));

            Assert.Equal(4, contraCheque.Lancamentos.Count);
            Assert.Equal(SALARIO_LIQUIDO_ESPERADO, contraCheque.SalarioLiquido);
            Assert.Equal(TOTAL_DESCONTOS_ESPERADO, contraCheque.TotalDescontos);
        }
    }
}
