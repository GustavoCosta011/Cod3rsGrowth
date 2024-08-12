using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Interfaces;
using FluentValidation;
using System.Reflection;
using FluentValidation.Results;
using System.ComponentModel;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoClube
    {
        private readonly IRepositoryData<Clube> repositoryClube;
        private readonly ValidadorClube validadorClube;

        public ServicoClube(IRepositoryData<Clube> repositoryMock, ValidadorClube validador)
        {
            repositoryClube = repositoryMock;
            validadorClube = validador; 
        }
        public List<ClubeDto> ObterTodos(Filtro? filtro)
        {
            var Clubes =  repositoryClube.ObterTodos(filtro);
            var ClubesDto = new List<ClubeDto>();

            foreach(Clube clube in Clubes)
            {
                var clubedto = new ClubeDto() {
                    Id = clube.Id,
                    Nome = clube.Nome,
                    Fundacao = clube.Fundacao.Date,
                    Estadio = clube.Estadio,
                    Estado = PegarODisplayName(clube.Estado),
                    CoberturaAntiChuva = clube.CoberturaAntiChuva,
                    Elenco = clube.Elenco
                };
                ClubesDto.Add(clubedto);
            }
            return ClubesDto.ToList();
        }
        public Clube ObterPorId(int id)
        {
            return repositoryClube.ObterPorId(id);

        }
        public int CriarClube(Clube clube)
        {
            ValidationResult resultado = validadorClube.Validate(clube);
            if (!resultado.IsValid)
            {
                throw new FluentValidation.ValidationException(resultado.Errors);
            }

            int IdNovoClube = repositoryClube.Criar(clube);

            return IdNovoClube;
            
        }

        public void EditarClube(Clube clube)
        {
            ValidationResult resultado = validadorClube.Validate(clube, opitons => opitons.IncludeRuleSets("Editar"));

            if (!resultado.IsValid)
            {
                throw new ValidationException(resultado.Errors);
            }
            repositoryClube.Editar(clube);
        }

        public void RemoverClube(int id)
        {
           repositoryClube.Remover(id);
        }

        public string PegarODisplayName(Enum EnumDoClube)
        {
            return EnumDoClube.GetType()
                            .GetMember(EnumDoClube.ToString())[0]
                            .GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>()?
                            .GetName() ?? EnumDoClube.ToString();
        }

        public string PegarDescrição(Enum value)
        {
            var enums = value.GetType().GetField(value.ToString());

            var DisplayDoEnum = enums.GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();
            if (DisplayDoEnum != null)
            {
                return DisplayDoEnum.Name;
            }

            return value.ToString();
        }
    }
}
