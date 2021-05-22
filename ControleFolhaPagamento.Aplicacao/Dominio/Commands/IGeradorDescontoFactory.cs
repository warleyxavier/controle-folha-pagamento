using System.Collections.Generic;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands
{
    public interface IGeradorDescontoFactory
    {
        IList<IGeradorDescontoCommand> Gerar();
    }
}
