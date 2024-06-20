using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Dominio.Interfaces;
using FluentValidation;
using FluentValidation.Results;


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
        public List<Clube> ObterTodos(Filtro? filtro)
        {
            return repositoryClube.ObterTodos(filtro);
        }
        public Clube ObterPorId(int id)
        {
            return repositoryClube.ObterPorId(id);

        }
        public int CriarClube(Clube clube)
        {
            ValidationResult resultado = validadorClube.Validate(clube);


            string? mensagem = null;
            string? separador = "\n";
            if (!resultado.IsValid)
            {
                mensagem = string.Join(separador, resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new ValidationException(mensagem);
            }

            int IdNovoClube = repositoryClube.Criar(clube);

            return IdNovoClube;
            
        }

        public void EditarClube( int id ,Clube clube)
        {
            var resultado = validadorClube.Validate(clube, opitons => opitons.IncludeRuleSets("Editar"));
            string? mensagem = null;
            string? separador = "\n";
            if (!resultado.IsValid)
            {
                mensagem = string.Join(separador,resultado.Errors.Select(erro => erro.ErrorMessage));
                throw new Exception(mensagem);
            }
            repositoryClube.Editar(id, clube);
        }

        public void RemoverClube(int id)
        {
           repositoryClube.Remover(id);
        } 
    }
}
