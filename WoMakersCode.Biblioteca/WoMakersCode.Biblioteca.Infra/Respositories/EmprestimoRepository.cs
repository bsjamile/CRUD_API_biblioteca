using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;

namespace WoMakersCode.Biblioteca.Infra.Respositories
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ApplicationContext _context;
        public EmprestimoRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task Atualizar(Emprestimo emprestimo)
        {
            _context.Entry(emprestimo).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var emprestimoToDelete = await _context.Emprestimos.FindAsync(id);
            var resultado = _context.Emprestimos.Remove(emprestimoToDelete);
            await _context.SaveChangesAsync();
            /*
            var emprestimoToDelete = await _context.Emprestimos.FindAsync(id);
            _context.Emprestimos.Remove(emprestimoToDelete);
            await _context.SaveChangesAsync();*/
        }

        public async Task Inserir(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Emprestimo>> ListarEmprestimosEmAtraso(int diasParaDevolucao)
        {
            return await _context
                .Emprestimos
                .Include(i => i.Livro)
                .Include(i => i.Usuario)
                .Where(w => w.DataDevolucao == null
                    && DateTime.Now > w.DataEmprestimo.AddDays(diasParaDevolucao))
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Emprestimo> ListarPorId(int id)
        {
            return await Task.FromResult(_context.Find<Emprestimo>(id));
        }

        public async Task<Emprestimo> ListarPorIdParaAtualizarEmprestimo(int id)
        {
            return await _context
                .Emprestimos
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Emprestimo>> ListarTodos()
        {
            return await _context
                .Emprestimos
                .AsNoTracking()
                .Include(i => i.Livro)
                    .ThenInclude(i => i.Autor)
                .Include(i => i.Usuario)
                    //.ThenInclude() traz as tabelas que estao vinculas à tabela Usuario, por exemplo
                .ToListAsync();
        }
    }
}
