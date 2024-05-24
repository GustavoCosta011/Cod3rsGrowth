using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Cod3rsGrowth.Dominio.Modelos;
using System.ComponentModel;

namespace Cod3rsGrowth.Dominio.Validadores
{
    public class ValidadorJogador : AbstractValidator<Jogador>
    {
        public ValidadorJogador()
        {
            RuleFor(jogador => jogador.Nome)
                .NotNull()
                .NotEmpty().WithMessage("Campo Obrigatorio!!")
                .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
            RuleFor(jogador => jogador.DataDeNascimento)
                .NotNull()
                .NotEmpty().WithMessage("Campo Obrigatorio!!")
                .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
            RuleFor(jogador => jogador.Idade)
               .NotNull()
               .NotEmpty().WithMessage("Campo Obrigatorio!!")
               .NotNull().WithMessage("O campo nao pode ser nulo!!")
               .LessThanOrEqualTo(jogador => DateTime.Now.Year - jogador.DataDeNascimento.Year).WithMessage("Idade incoerente a data de nascimento!!");
            RuleFor(jogador => jogador.Altura)
                .NotNull()
                .NotEmpty().WithMessage("Campo Obrigatorio!!");
            RuleFor(jogador => jogador.Peso)
                .NotNull()
                .NotEmpty().WithMessage("Campo Obrigatorio!!");

        }

    }
}
