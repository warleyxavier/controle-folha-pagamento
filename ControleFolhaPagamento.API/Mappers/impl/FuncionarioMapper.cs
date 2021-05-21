using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.Aplicacao.Dominio.Model;
using System;

namespace ControleFolhaPagamento.API.Mappers.impl
{
    public class FuncionarioMapper : IFuncionarioMapper
    {
        public Funcionario ParaEntidade(FuncionarioParaInsercaoDto dto)
        {
            return new Funcionario()
            {
                Nome = dto.nome,
                SobreNome = dto.sobrenome,
                Setor = dto.setor,
                Documento = dto.documento,
                SalarioBruto = dto.salariobruto,
                PossuiPlanoDental = dto.possuiPlanoDental,
                PossuiPlanoSaude = dto.possuiPlanoSaude,
                PossuiValeTransporte = dto.possuiValeTransporte
            };
        }

        public CodigoFuncionarioInseridoDto ParaCodigoInseridoDto(int codigoInserido)
        {
            return new CodigoFuncionarioInseridoDto()
            {
                codigoInserido = codigoInserido
            };
        }
    }
}
