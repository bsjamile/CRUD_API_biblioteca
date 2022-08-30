using System;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.DTOs
{
    public class LivroEmprestadoDTO
    {
        public string TituloLivro { get; set; }
        public string NomeAutor { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
