using Microsoft.EntityFrameworkCore;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.Aplicacao.Infraestrutura.Contexts
{
    public class GlobalContext : DbContext
    {
        public GlobalContext()
        {
        }

        public GlobalContext(DbContextOptions<GlobalContext> options): base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
