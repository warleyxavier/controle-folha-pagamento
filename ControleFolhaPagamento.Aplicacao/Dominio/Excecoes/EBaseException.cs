using System;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Excecoes
{
    public class EBaseException : Exception
    {
        public EBaseException(int statusCode, string mensagem): base(mensagem)
        {
            StatusCode = statusCode;
        }
        public int StatusCode { get; private set; }
    }
}
