using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;

namespace ControleFolhaPagamento.API.Mappers
{
    public interface IFuncionarioMapper
    {
        public Funcionario ParaEntidade(FuncionarioParaInsercaoDto dto);
    }
}
