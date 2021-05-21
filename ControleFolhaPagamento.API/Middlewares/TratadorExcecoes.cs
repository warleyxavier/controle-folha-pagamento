using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using Microsoft.AspNetCore.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControleFolhaPagamento.API.Middlewares
{
    public class TratadorExcecoes
    {
        private readonly RequestDelegate next;

        public TratadorExcecoes(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception e)
            {
                await PadronizarResposta(httpContext, e);
            };
        }

        private async Task PadronizarResposta(HttpContext httpContext, Exception e)
        {
            int statusCode = 500;

            if (e is BaseException exception)
                statusCode = exception.StatusCode;

            string resposta = ConverterExcecaoParaJson(e);

            httpContext.Response.Clear();
            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.Headers.Add("Content-Type", "application/json");
            await httpContext.Response.WriteAsync(resposta);
        }

        public string ConverterExcecaoParaJson(Exception e)
        {
            if (e is ValidacaoException exception)
                return JsonSerializer.Serialize(new FalhaRequisicaoComErrosDto(exception.Message, exception.Erros));

            return JsonSerializer.Serialize(new FalhaRequisicaoDto(e.Message));
        }
    }
}
