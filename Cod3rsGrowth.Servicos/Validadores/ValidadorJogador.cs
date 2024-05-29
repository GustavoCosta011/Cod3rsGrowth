using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;


namespace Cod3rsGrowth.Servicos.Validadores
{
    public class ValidadorJogador : AbstractValidator<Jogador>
    {
        public ValidadorJogador()
        {
            RuleFor(jogador => jogador.Nome)
                .NotNull()
                .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
            RuleFor(jogador => jogador.DataDeNascimento)
                .NotNull()
                .NotEmpty().WithMessage("Campo não pode ser vazio!!")
                .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
            RuleFor(jogador => jogador.Idade)
               .NotEmpty().WithMessage("Campo não pode ser vazio!!")
               .LessThanOrEqualTo(jogador => DateTime.Now.Year - jogador.DataDeNascimento.Year).WithMessage("Idade incoerente a data de nascimento!!");
            RuleFor(jogador => jogador.Altura)
                .NotEmpty().WithMessage("Campo não pode ser vazio!!");
            RuleFor(jogador => jogador.Peso)
                .NotEmpty().WithMessage("Campo não pode ser vazio!!");
            
            RuleSet("Editar", () =>
            {
                RuleFor(jogador => jogador.Nome)
                    .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                RuleFor(jogador => jogador.DataDeNascimento)
                    .NotNull().WithMessage("Campo obrigatorio!!")
                    .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
                RuleFor(jogador => jogador.Idade)
                    .LessThanOrEqualTo(jogador => DateTime.Now.Year - jogador.DataDeNascimento.Year).WithMessage("Idade incoerente a data de nascimento!!");
            });
        }
    }
}
