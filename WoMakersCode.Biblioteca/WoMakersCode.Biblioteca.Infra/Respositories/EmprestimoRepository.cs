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
            _context.Update(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(Emprestimo emprestimo)
        {
            _context.Remove(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Emprestimo emprestimo)
        {
            _context.Add(emprestimo);
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
            return await _context
                .Emprestimos
                .Where(w => w.Id == id)
                .AsNoTracking()
                .FirstOrDefaultAsync();
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
                .Include(i => i.Livro)
                    .ThenInclude(i => i.Autor)
                .Include(i => i.Usuario)
                    //.ThenInclude() traz as tabelas que estao vinculas à tabela Usuario, por exemplo
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
