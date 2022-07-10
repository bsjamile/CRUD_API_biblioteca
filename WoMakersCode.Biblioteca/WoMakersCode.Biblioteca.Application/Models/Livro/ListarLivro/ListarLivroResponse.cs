
namespace WoMakersCode.Biblioteca.Application.Models.ListarLivro
{
    public class ListarLivroResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int IdAutor { get; set; }
    }
}
