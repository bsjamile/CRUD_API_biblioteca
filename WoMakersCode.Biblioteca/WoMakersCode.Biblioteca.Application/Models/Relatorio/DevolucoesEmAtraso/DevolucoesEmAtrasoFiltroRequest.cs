using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.Relatorio.DevolucoesEmAtraso
{
    public class DevolucoesEmAtrasoFiltroRequest
    {
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string NomeUsuario { get; set; }
        public string TituloLivro { get; set; }
    }
}
