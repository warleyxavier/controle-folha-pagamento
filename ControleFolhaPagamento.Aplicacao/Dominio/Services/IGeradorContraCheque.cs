using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services
{
    public interface IGeradorContraCheque
    {
        ContraCheque Gerar(int codigoFuncionario);
    }
}
