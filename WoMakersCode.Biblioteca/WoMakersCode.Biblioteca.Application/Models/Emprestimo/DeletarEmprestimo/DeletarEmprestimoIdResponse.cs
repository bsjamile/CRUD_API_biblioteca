using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.Emprestimo.DeletarEmprestimo
{
    public class DeletarEmprestimoIdResponse
    {
        public int Id { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
    }
}
