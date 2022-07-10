using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;

namespace WoMakersCode.Biblioteca.Infra.Respositories
{
    public class AutorRepository : IAutorRepository
    {
        private readonly ApplicationContext _context;
        public AutorRepository(ApplicationContext context)
        {
            _context = context;
        }

            public async Task Atualizar(Autor autor)
        {
            _context.Entry(autor).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var autorToDelete = await _context.Autores.FindAsync(id);
            var resultado = _context.Autores.Remove(autorToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Autor autor)
        {
            _context.Add(autor);
            _context.SaveChanges();
        }

        public async Task<Autor> ListarPorId(int id)
        {
            return await Task.FromResult(_context.Find<Autor>(id));
        }

        public async Task<IEnumerable<Autor>> ListarTodos()
        {
            return await _context
                .Autores
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
