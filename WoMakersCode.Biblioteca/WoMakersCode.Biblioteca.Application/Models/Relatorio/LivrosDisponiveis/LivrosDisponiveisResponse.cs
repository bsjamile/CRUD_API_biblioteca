using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosDisponiveis
{
    public class LivrosDisponiveisResponse
    {
        public string TituloLivro { get; set; }
        public string NomeAutor { get; set; }
        public int QtdDisponivel { get; set; }
        public decimal QtdEmp { get; set; }
    }
}
