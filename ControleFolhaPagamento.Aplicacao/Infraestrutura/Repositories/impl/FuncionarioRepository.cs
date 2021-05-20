using System;
using System.Linq;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Contexts;

namespace ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories.impl
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly GlobalContext context;

        public FuncionarioRepository(GlobalContext context)
        {
            this.context = context;
        }

        public Funcionario Inserir(Funcionario funcionario)
        {
            int count = this.context.Funcionarios.Count();

            this.context.Funcionarios.Add(funcionario);
            this.context.SaveChanges();
            return funcionario;
        }

        public Funcionario Pesquisar(int id)
        {
            return this.context.Funcionarios.Where(funcionario => funcionario.Id == id).FirstOrDefault();
        }
    }
}
