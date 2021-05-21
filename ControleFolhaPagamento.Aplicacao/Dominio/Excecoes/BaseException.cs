using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Excecoes
{
    public class BaseException : Exception
    {
        public BaseException(int statusCode, string mensagem): base(mensagem)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; private set; }
    }
}
