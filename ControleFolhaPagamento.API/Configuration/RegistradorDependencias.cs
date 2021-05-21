using Microsoft.Extensions.DependencyInjection;
using ControleFolhaPagamento.Aplicacao.Dominio.Services;
using ControleFolhaPagamento.Aplicacao.Dominio.Services.impl;
using ControleFolhaPagamento.API.Mappers;
using ControleFolhaPagamento.API.Mappers.impl;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Repositories.impl;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores;
using ControleFolhaPagamento.Aplicacao.Dominio.Validadores.impl;

namespace ControleFolhaPagamento.API.Configuration
{
    public static class RegistradorDependencias
    {
        public static IServiceCollection RegistrarDependencias(this IServiceCollection services)
        {
            services.AddScoped<IFuncionarioMapper, FuncionarioMapper>();

            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IValidadorFuncionario, ValidadorFuncionario>();
            services.AddScoped<IGerenciadorFuncionario, GerenciadorFuncionario>();
            services.AddScoped<IGeradorContraCheque, GeradorContraCheque>();

            return services;
        }
    }
}
