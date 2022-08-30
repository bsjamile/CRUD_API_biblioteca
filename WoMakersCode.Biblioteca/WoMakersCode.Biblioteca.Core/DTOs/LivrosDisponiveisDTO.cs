using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.Core.DTOs
{
    public class LivrosDisponiveisDTO
    {
        public string TituloLivro { get; set; }
        public string NomeAutor { get; set; }
        public int QtdDisponivel { get; set; }
        public decimal QtdEmp { get; set; }
    }
}
