using ControleFolhaPagamento.API.Dto;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using System;

namespace ControleFolhaPagamento.API.Mappers.impl
{
    public class FuncionarioMapper : IFuncionarioMapper
    {
        public Funcionario ParaEntidade(FuncionarioParaInsercaoDto dto)
        {
            var entidade = new Funcionario()
            {
                Nome = dto.nome,
                SobreNome = dto.sobrenome,
                Setor = dto.setor,
                SalarioBruto = dto.salariobruto,
                PossuiPlanoDental = dto.possuiPlanoDental,
                PossuiPlanoSaude = dto.possuiPlanoSaude,
                PossuiValeTransporte = dto.possuiValeTransporte
            };

            return entidade;
        }
    }
}
