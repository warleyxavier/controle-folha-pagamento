using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;

namespace ControleFolhaPagamento.API.Mappers
{
    public interface IFuncionarioMapper
    {
        public Funcionario ParaEntidade(FuncionarioParaInsercaoDto dto);
        public CodigoFuncionarioInseridoDto ParaCodigoInseridoDto(int codigoInserido);
    }
}
