using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.Repositories
{
    public interface IEmprestimoRepository : IRepository<Emprestimo>
    {
        Task<Emprestimo> ListarPorIdParaAtualizarEmprestimo(int Id);
        Task<List<Emprestimo>> ListarEmprestimosEmAtraso(int diasParaDevolucao);
    }
}
