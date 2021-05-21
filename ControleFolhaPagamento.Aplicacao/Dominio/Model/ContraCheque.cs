namespace ControleFolhaPagamento.Aplicacao.Dominio.Model
{
    public class ContraCheque
    {
        public int Mes { get; set; }
        public double SalarioBruto { get; set; }
        public double TotalDescontos { get; set; }
        public double SalarioLiquido { get; set; }
    }
}
