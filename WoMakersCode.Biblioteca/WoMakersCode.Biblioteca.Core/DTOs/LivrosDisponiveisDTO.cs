using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.DTOs
{
    public class LivrosDisponiveisDTO
    {
        public string TituloLivro { get; set; }
        public Livro Livro { get; set; }
        public string NomeAutor { get; set; }
        public Autor Autor { get; set; }
        public int QtdDisponivel { get; set; }
        public decimal QtdEmp { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
