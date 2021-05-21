using FluentValidation;
using FluentValidation.Results;
using ControleFolhaPagamento.Aplicacao.Dominio.Entidades;
using ControleFolhaPagamento.Aplicacao.Dominio.Excecoes;
using System.Collections.Generic;
using System.Linq;

namespace ControleFolhaPagamento.Aplicacao.Dominio.Validadores.impl
{
    public class ValidadorFuncionario : AbstractValidator<Funcionario>, IValidadorFuncionario
    {
        public ValidadorFuncionario()
        {
            const string REGEX_PARA_VALIDAR_CPF = @"^\d{3}\.?\d{3}\.?\d{3}\-?\d{2}$";
            const string MENSAGEM_PADRAO = "{PropertyName} não foi informado";

            RuleFor(funcionario => funcionario.Nome).NotEmpty().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.SobreNome).NotEmpty().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.Setor).NotEmpty().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.Documento).NotEmpty().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.Documento).Matches(REGEX_PARA_VALIDAR_CPF).WithMessage("O {PropertyName} informado é inválido");
            RuleFor(funcionario => funcionario.SalarioBruto).GreaterThan(0).WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.PossuiPlanoDental).NotNull().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.PossuiPlanoSaude).NotNull().WithMessage(MENSAGEM_PADRAO);
            RuleFor(funcionario => funcionario.PossuiValeTransporte).NotNull().WithMessage(MENSAGEM_PADRAO);            
        }

        public void Validar(Funcionario funcionario)
        {
            ValidationResult resultadosValidacao = this.Validate(funcionario);

            if (resultadosValidacao.IsValid)
                return;

            throw new ValidacaoException(ConverterParaArrayDeErros(resultadosValidacao.Errors));
        }

        private string[] ConverterParaArrayDeErros(List<ValidationFailure> falhas)
        {
            return falhas.Select(falha =>
            {
                return falha.ErrorMessage;
            }).ToArray();
        }
    }
}
