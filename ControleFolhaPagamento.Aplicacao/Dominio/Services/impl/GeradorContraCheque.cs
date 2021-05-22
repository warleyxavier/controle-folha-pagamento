using ControleFolhaPagamento.Aplicacao.Dominio.Commands;
using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using System;
using System.Collections.Generic;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services.impl
{
    public class GeradorContraCheque : IGeradorContraCheque
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IList<IGeradorDescontoCommand> geradoresDesconto;

        public GeradorContraCheque(IFuncionarioRepository funcionarioRepository, IGeradorDescontoFactory geradorDescontoFactory)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.geradoresDesconto = geradorDescontoFactory.Gerar();
        }

        public ContraCheque Gerar(int codigoFuncionario)
        {
            var funcionario = this.funcionarioRepository.Pesquisar(codigoFuncionario);

            if (funcionario == null)
                throw new EBaseException(404, "Funcionário não encontrado");

            return ConstruirContraCheque(funcionario);
        }

        private ContraCheque ConstruirContraCheque(Funcionario funcionario)
        {
            var contraCheque = new ContraCheque(funcionario.SalarioBruto);

            foreach (var geradorDesconto in this.geradoresDesconto)
            {
                if (!geradorDesconto.DeveGerar(funcionario))
                    continue;

                contraCheque.AdicionarDesconto(geradorDesconto.Gerar(funcionario));
            };

            return contraCheque;
        }
    }
}
