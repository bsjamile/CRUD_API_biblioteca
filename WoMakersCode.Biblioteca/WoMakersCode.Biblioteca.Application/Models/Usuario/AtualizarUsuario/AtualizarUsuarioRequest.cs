namespace WoMakersCode.Biblioteca.Application.Models.Usuario.AtualizarUsuario
{
    public class AtualizarUsuarioRequest
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}
