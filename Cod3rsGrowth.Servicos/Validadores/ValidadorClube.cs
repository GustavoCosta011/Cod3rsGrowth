using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Servicos.Validadores
{
        public class ValidadorClube : AbstractValidator<Clube>
        {
            public ValidadorClube()
            {
                RuleFor(club => club.Nome)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                    .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                RuleFor(clube => clube.Fundacao)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                    .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
                RuleFor(clube => clube.Estadio)
                    .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                RuleFor(clube => clube.Estado)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                    .IsInEnum().WithMessage("O valor deve ser a sigla da unidade federativa de fundacao!!");
                RuleFor(clube => clube.CoberturaAntiChuva)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .NotEmpty().WithMessage("Campo não pode ser vazio!!");
                RuleFor(clube => clube.Elenco)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .NotEmpty().WithMessage("Campo não pode ser vazio!!");
            
                RuleSet("Editar", () =>
                {
                    RuleFor(club => club.Nome)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                       .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                    RuleFor(clube => clube.Fundacao)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                       .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
                    RuleFor(clube => clube.Estadio)
                       .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                    RuleFor(clube => clube.Estado)
                       .Cascade(CascadeMode.StopOnFirstFailure)
                       .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                       .IsInEnum().WithMessage("O valor deve ser a sigla da unidade federativa de fundacao!!");
                    
                });
            }
        }
}
