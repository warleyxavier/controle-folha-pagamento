using System.Collections.Generic;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Commands.impl
{
    public class GeradorDescontoFactory : IGeradorDescontoFactory
    {
        public IList<IGeradorDescontoCommand> Gerar()
        {
            return new List<IGeradorDescontoCommand>() {
                new GeradorDescontoINSSCommand(),
                new GeradorDescontoImpostoRendaCommand(),
                new GeradorDescontoPlanoSaudeCommand(),
                new GeradorDescontoPlanoDentalCommand(),
                new GeradorDescontoValeTransporteCommand(),
                new GeradorDescontoFGTSCommand()
            };
        }
    }
}
