using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Services.impl
{
    public class GerenciadorFuncionario : IGerenciadorFuncionario
    {
        public int inserir(Funcionario funcionario)
        {
            var random = new Random();

            return random.Next();
        }

        public Funcionario pesquisar(int id)
        {
            return new Funcionario()
            {
                Id = id,
                Nome = "Warley",
                SobreNome = "Xavier",
                Setor = "TI",
                SalarioBruto = 500.00,
                PossuiPlanoDental = true,
                PossuiPlanoSaude = false,
                PossuiValeTransporte = true
            };
        }
    }
}
