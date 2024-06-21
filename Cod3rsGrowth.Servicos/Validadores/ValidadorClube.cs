using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidadorClube : AbstractValidator<Clube>
    {
        public ValidadorClube()
        {
            RuleFor(clube => clube.Nome)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Campo 'Nome' obrigatório!")
                .NotEmpty().WithMessage("Campo 'Nome' não pode ser vazio!")
                .Length(3, 60).WithMessage("O nome deve ter entre 3 e 60 caracteres!");

            RuleFor(clube => clube.Fundacao)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("Campo 'Fundação' obrigatório!")
                .NotEmpty().WithMessage("Campo 'Fundação' não pode ser vazio!")
                .LessThanOrEqualTo(DateTime.Now.AddDays(1)).WithMessage("A data deve ser anterior ou igual à data atual!");

            RuleFor(clube => clube.Estadio)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(3, 60).WithMessage("O nome do estádio deve ter entre 3 e 60 caracteres!");

            RuleFor(clube => clube.Estado)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(estado => estado >= 0).WithMessage("Campo 'Estado' não pode ser vazio!")
                .IsInEnum().WithMessage("O valor deve ser a sigla da unidade federativa!");

            RuleFor(clube => clube.CoberturaAntiChuva)
                .NotEmpty().WithMessage("Campo 'Cobertura Antichuva' deve ser preenchido!")
                .Must(value => value == true || value == false)
                .WithMessage("Campo 'Cobertura Antichuva' deve ser verdadeiro ou falso.");

            RuleSet("Editar", () =>
            {
                RuleFor(clube => clube.Nome)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Campo 'Nome' não pode ser vazio!")
                    .Length(3, 60).WithMessage("O nome deve ter entre 3 e 60 caracteres!");

                RuleFor(clube => clube.Fundacao)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("Campo 'Fundação' não pode ser vazio!")
                    .LessThanOrEqualTo(DateTime.Now).WithMessage("A data deve ser anterior ou igual à data atual!");

                RuleFor(clube => clube.Estadio)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .Length(3, 60).WithMessage("O nome do estádio deve ter entre 3 e 60 caracteres!");

                RuleFor(clube => clube.Estado)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .Must(estado => estado >= 0).WithMessage("Campo 'Estado' não pode ser vazio!")
                    .IsInEnum().WithMessage("O valor deve ser a sigla da unidade federativa!");
            });
        }
    }
}
