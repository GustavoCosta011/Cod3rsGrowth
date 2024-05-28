using Cod3rsGrowth.Dominio.Modelos;
using Cod3rsGrowth.Dominio.Validadores;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.RepositoriosTest;
using FluentValidation;
using FluentValidation.Results;


namespace Cod3rsGrowth.Servicos.Servicos
{
    public class ServicoClube : IServicoClube
    {
        private readonly IRepositoryData<Clube> repositoryClube;
        private readonly ValidadorClube validadorClube;

        public ServicoClube(IRepositoryData<Clube> repositoryMock, ValidadorClube validador)
        {
            repositoryClube = repositoryMock;
            validadorClube = validador; 
        }
        public List<Clube> ObterTodos()
        {
            return repositoryClube.ObterTodos();
        }
        public Clube ObterPorId(int id)
        {
            return repositoryClube.ObterPorId(id);

        }
        public int? CriarClube(Clube clube)
        {
            ValidationResult resultado = validadorClube.Validate(clube);


            if (!resultado.IsValid)
            {
                string? mensagem = null;

                foreach (var erro in resultado.Errors)
                {
                    mensagem += erro.ErrorMessage;

                }

                throw new Exception(mensagem);
            }

            int? IdNovoClube = repositoryClube.Criar(clube);

            return IdNovoClube;
            
        }

        public void EditarClube( int id ,Clube clube)
        {
            var resultado = validadorClube.Validate(clube, opitons => opitons.IncludeRuleSets("Editar"));


            if (!resultado.IsValid)
            {
                string? mensagem = null;

                foreach (var erro in resultado.Errors)
                {
                    mensagem += erro.ErrorMessage;

                }
                
                throw new Exception(mensagem);
            }
            repositoryClube.Editar(id, clube);
        }

        /*public void RemoverClube(int id)
        {
           repositoryClube.Remover(id);
        }   */
    }
}
