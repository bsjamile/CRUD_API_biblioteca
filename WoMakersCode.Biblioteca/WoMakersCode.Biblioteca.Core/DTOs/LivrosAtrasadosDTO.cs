using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.DTOs
{
    public class LivrosAtrasadosDTO
    {
        public string TituloLivro { get; set; }
        public string NomeAutor { get; set; }
        public string NomeUsuario { get; set; }
       public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int DiasEmAtraso { get; set; }
        public decimal ValorMulta { get; set; }
    }
}
