namespace Cod3rsGrowth.Dominio.Interfaces

{
    public interface IRepositoryData<T> where T : class
    {
        List<T> ObterTodos(string serch);
        int  Criar(T objeto);
        T? ObterPorId(int id);
        void Editar(int id,T objeto);
        void Remover(int id);
        
    }

}


