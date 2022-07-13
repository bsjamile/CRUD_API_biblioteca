using System.Collections.Generic;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Core.Repositories
{
   public interface IRepository<T>
    {
        Task Inserir(T obj);
        Task Atualizar(T obj);
        Task<IEnumerable<T>> ListarTodos();
        Task <T> ListarPorId(int id);
        Task Excluir (T obj);

    }
}
