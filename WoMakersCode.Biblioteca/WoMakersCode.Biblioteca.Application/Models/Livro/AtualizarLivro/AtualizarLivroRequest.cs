
namespace WoMakersCode.Biblioteca.Application.Models.Livro.AtualizarLivro
{
    public class AtualizarLivroRequest
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int IdAutor { get; set; }
    }
}
