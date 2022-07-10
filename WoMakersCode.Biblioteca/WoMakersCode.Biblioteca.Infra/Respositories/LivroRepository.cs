using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;

namespace WoMakersCode.Biblioteca.Infra.Respositories
{
    public class LivroRepository : ILivroRepository
    {
        private readonly ApplicationContext _context;
        public LivroRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var livroToDelete = await _context.Livros.FindAsync(id);
            var resultado = _context.Livros.Remove(livroToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
        }

        public async Task<Livro> ListarPorId(int id)
        {
            return await Task.FromResult(_context.Find<Livro>(id));
        }

        public async Task<IEnumerable<Livro>> ListarTodos()
        {
            return await _context
                .Livros
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
