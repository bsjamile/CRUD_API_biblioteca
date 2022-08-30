using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.Models.Relatorio.DevolucoesEmAtraso
{
    public class DevolucoesEmAtrasoResponse
    {
        public string TituloLivro { get; set; }
        public string NomeAutor { get; set; }
        public string NomeUsuario { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }/*
        public int DiasEmAtraso { get; set; }
        public decimal ValorMulta { get; set; }*/
    }
}
