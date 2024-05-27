using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Dominio.Modelos;
using FluentValidation;

namespace Cod3rsGrowth.Dominio.Validadores
{
        public class ValidadorClube : AbstractValidator<Clube>
        {
            public ValidadorClube()
            {
                RuleFor(club => club.Nome)
                    .NotEmpty().WithMessage("Campo Obrigatorio!!")
                    .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                RuleFor(clube => clube.Fundacao)
                    .NotEmpty().WithMessage("Campo Obrigatorio!!")
                    .LessThanOrEqualTo(jogador => DateTime.Now).WithMessage("A data deve ser anterior a atual!!");
                RuleFor(clube => clube.Estadio)
                    .Length(3, 60).WithMessage("O nome tem que ter no minimo 3 e no maximo 60 letras!!");
                RuleFor(clube => clube.Estado)
                    .NotEmpty().WithMessage("Campo Obrigatorio!!")
                    .IsInEnum().WithMessage("O valor deve ser a sigla da unidade federativa de fundacao!!");
                RuleFor(clube => clube.CoberturaAntiChuva)
                    .NotEmpty().WithMessage("Campo Obrigatorio!!");
                RuleFor(clube => clube.Elenco)
                    .NotEmpty().WithMessage("Campo Obrigatorio!!");
                    



            }

        }
}
