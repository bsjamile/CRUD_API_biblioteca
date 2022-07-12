using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.Emprestimo.AdicionarEmprestimo
{
    public class AdicionarEmprestimoRequest
    {
        public DateTime DataEmprestimo { get; set; }
        public int IdUsuario { get; set; }
    }
}
