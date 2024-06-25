namespace Cod3rsGrowth.Dominio.Interfaces

{
    public interface IRepositoryData<T> where T : class
    {
        List<T> ObterTodos(Filtro? filtro);
        int  Criar(T objeto);
        T? ObterPorId(int id);
        void Editar(T objeto);
        void Remover(int id);
        
    }

}


