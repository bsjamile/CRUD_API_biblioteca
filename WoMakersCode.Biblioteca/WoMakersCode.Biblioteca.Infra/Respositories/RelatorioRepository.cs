using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.DTOs;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;

namespace WoMakersCode.Biblioteca.Infra.Respositories
{
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly ApplicationContext _context;

        public RelatorioRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<IEnumerable<LivrosDisponiveisDTO>> RelatorioLivrosDisponiveis(string nomeUsuario, string tituloLivro)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<LivrosAtrasadosDTO>> RelatorioLivrosEmAtraso(DateTime? dataInicio, DateTime? dataDevolucao, string nomeUsuario, string tituloLivro)
        {
            var registros = _context
                .Emprestimos
                .Include(i => i.Livro)
                    .ThenInclude(ti => ti.Autor)
                .Include(i => i.Usuario)
                .AsNoTracking()
                .AsQueryable();

            if (dataInicio != null)
                registros = registros.Where(w => w.DataEmprestimo == dataInicio);

            if (!string.IsNullOrEmpty(tituloLivro))
                registros = registros.Where(w => w.Livro.Titulo.Contains(tituloLivro));

            var resposta = await registros
                 .Select(s => new LivrosAtrasadosDTO()
                 {
                     TituloLivro = s.Livro.Titulo,
                     NomeAutor = s.Livro.Autor.Nome,
                     NomeUsuario = s.Usuario.Nome,
                     DataEmprestimo = s.DataEmprestimo/*
                     DataDevolucao = s.DataEmprestimo.AddDays(7),
                     ValorMulta = (DateTime.Now - s.DataEmprestimo.AddDays(7)).Days * 0.5M*/
                 })
                  .ToListAsync();

            return resposta;
        }

        public async Task<IEnumerable<LivroEmprestadoDTO>> RelatorioLivrosEmprestados(DateTime? dataInicio, DateTime? dataDevolucao)
        {
            var registros = _context
               .Emprestimos
               .Include(i => i.Livro)
               .Include(i => i.Usuario)
               .Where(w => w.DataDevolucao == null
                   && w.DataEmprestimo >= DateTime.Now.AddDays(-7))
               .AsNoTracking()
               .AsQueryable();

            if (dataInicio != null)
                registros = registros.Where(w => w.DataEmprestimo >= dataInicio);

            if (dataDevolucao != null)
                registros = registros.Where(w => w.DataEmprestimo <= dataInicio);

            var resposta = await registros
                .Select(s => new LivroEmprestadoDTO()
                {
                    TituloLivro = s.Livro.Titulo,
                    NomeUsuario = s.Usuario.Nome,
                    DataEmprestimo = s.DataEmprestimo,
                    DataDevolucao = s.DataEmprestimo.AddDays(7)
                })
                 .ToListAsync();

            return resposta;
        }
    }
}
