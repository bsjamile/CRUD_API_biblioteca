﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
            _context.Emprestimos.Remove(emprestimoToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(Emprestimo emprestimo)
        {
            _context.Emprestimos.Add(emprestimo);
            await _context.SaveChangesAsync();
        }

        public async Task<Emprestimo> ListarPorId(int id)
        {
            return await Task.FromResult(_context.Find<Emprestimo>(id));
        }

        public async Task<IEnumerable<Emprestimo>> ListarTodos()
        {
            return await _context
                .Emprestimos
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
