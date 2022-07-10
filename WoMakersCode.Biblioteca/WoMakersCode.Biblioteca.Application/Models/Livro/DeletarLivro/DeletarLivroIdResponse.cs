namespace WoMakersCode.Biblioteca.Application.Models.DeletarLivro
{
    public class DeletarLivroIdResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int IdAutor { get; set; }
    }
}
