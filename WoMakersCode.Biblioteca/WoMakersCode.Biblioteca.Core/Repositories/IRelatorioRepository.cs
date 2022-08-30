using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.DTOs;

namespace WoMakersCode.Biblioteca.Core.Repositories
{
    public interface IRelatorioRepository
    {
        Task<IEnumerable<LivrosAtrasadosDTO>> RelatorioLivrosEmAtraso(DateTime? dataInicio, DateTime? dataDevolucao, string nomeUsuario, string tituloLivro);
        Task<IEnumerable<LivroEmprestadoDTO>> RelatorioLivrosEmprestados(DateTime? dataInicio, DateTime? dataDevolucao);
        Task<IEnumerable<LivrosDisponiveisDTO>> RelatorioLivrosDisponiveis(string nomeUsuario, string tituloLivro);

    }
}
