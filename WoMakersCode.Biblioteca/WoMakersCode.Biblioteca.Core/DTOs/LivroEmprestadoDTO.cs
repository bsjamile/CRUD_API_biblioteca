using System;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.DTOs
{
    public class LivroEmprestadoDTO
    {
        public string TituloLivro { get; set; }
        public Livro Livro { get; set; }
        public string NomeAutor { get; set; }
        public Autor Autor { get; set; }
        public int NomeUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
