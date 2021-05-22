namespace ControleFolhaPagamento.Aplicacao.Dominio.Excecoes
{
    public class EValidacaoException : EBaseException
    {
        const int BAD_REQUEST_STATUS_CODE = 400;
        const string MENSAGEM = "Falha na validação dos dados";

        public EValidacaoException(string[] erros): base(BAD_REQUEST_STATUS_CODE, MENSAGEM)
        {
            Erros = erros;
        }
        public string[] Erros { get; private set; }
    }
}
