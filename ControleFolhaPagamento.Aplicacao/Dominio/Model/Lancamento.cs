using ControleFolhaPagamento.Aplicacao.Dominio.Enums;
using System.Text.Json.Serialization;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Model
{
    public class Lancamento
    {
        public Lancamento(TipoLancamento tipo, double valor, string descricao)
        {
            Tipo = tipo;
            Valor = valor;
            Descricao = descricao;
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TipoLancamento Tipo { get; private set; }
        public double Valor { get; private set; }
        public string Descricao { get; private set; }        
    }
}
