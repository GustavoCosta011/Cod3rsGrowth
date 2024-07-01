using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;
using System;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidadorJogador : AbstractValidator<Jogador>
    {
        public ValidadorJogador()
        {
            RuleFor(jogador => jogador.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Campo 'Nome' não pode ser vazio!")
                .NotEmpty().WithMessage("Campo 'Nome' não pode ser vazio!")
                .Length(3, 60).WithMessage("O nome deve ter entre 3 e 60 caracteres!");

            RuleFor(jogador => jogador.DataDeNascimento)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Campo 'Data de Nascimento' é obrigatório!")
                .NotEmpty().WithMessage("Campo 'Data de Nascimento' é obrigatório!")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data deve ser anterior ou igual à data atual!");

            RuleFor(jogador => jogador.Idade)
                .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                .LessThanOrEqualTo(jogador => DateTime.Now.Year - jogador.DataDeNascimento.Year).WithMessage("Idade incoerente a data de nascimento!!");

            RuleFor(jogador => jogador.Altura)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty().WithMessage("Campo 'Altura' não pode ser vazio!");

            RuleFor(jogador => jogador.Peso)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("Campo 'Peso' não pode ser vazio!");

            RuleSet("Editar", () =>
            {
                RuleFor(jogador => jogador.Nome)
                    .NotEmpty().WithMessage("Campo editado 'Nome' não pode ser alterado para vazio!")
                    .Length(3, 60).WithMessage("O nome deve ter entre 3 e 60 caracteres!");

                RuleFor(jogador => jogador.DataDeNascimento)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo 'Data de Nascimento' é obrigatório!")
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("A data deve ser anterior ou igual à data atual!");
                RuleFor(jogador => jogador.Altura)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull()
                    .NotEmpty().WithMessage("Campo editado 'Altura' não pode ser alterado para vazio!");
                RuleFor(jogador => jogador.Peso)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Campo editado 'Peso' não pode ser alterado para vazio!");
            });
        }
    }
}
