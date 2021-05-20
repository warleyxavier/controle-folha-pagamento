using Microsoft.Extensions.DependencyInjection;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Dominio.Services.impl;
using ControleFolhaPagamento.API.Mappers;
using ControleFolhaPagamento.API.Mappers.impl;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories.impl;

namespace ControleFolhaPagamento.API.Configuration
{
    public static class RegistradorDependencias
    {
        public static IServiceCollection RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioMapper, FuncionarioMapper>();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IGerenciadorFuncionario, GerenciadorFuncionario>();

            return services;
        }
    }
}
