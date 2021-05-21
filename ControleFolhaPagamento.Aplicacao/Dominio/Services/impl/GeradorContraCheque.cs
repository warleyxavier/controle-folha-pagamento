using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services.impl
{
    public class GeradorContraCheque : IGeradorContraCheque
    {
        private readonly IFuncionarioRepository funcionarioRepository;

        public GeradorContraCheque(IFuncionarioRepository funcionarioRepository)
        {
            this.funcionarioRepository = funcionarioRepository;
        }

        public ContraCheque Gerar(int codigoFuncionario)
        {
            var funcionario = this.funcionarioRepository.Pesquisar(codigoFuncionario);

            if (funcionario == null)
                throw new EBaseException(400, "Funcionário não encontrado");

            return ConstruirContraCheque(funcionario);
        }

        private ContraCheque ConstruirContraCheque(Funcionario funcionario)
        {
            var contraCheque = new ContraCheque()
            {
                Mes = new DateTime().Month,
                SalarioBruto = funcionario.SalarioBruto,
                SalarioLiquido = funcionario.SalarioBruto,
                TotalDescontos = 0
            };

            return contraCheque;
        }
    }
}
