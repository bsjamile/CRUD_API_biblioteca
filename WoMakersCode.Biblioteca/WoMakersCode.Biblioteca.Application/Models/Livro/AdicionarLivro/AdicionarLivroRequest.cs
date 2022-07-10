using FluentValidation;

namespace WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario
{
    public class AdicionarLivroRequest
    {
        public string Titulo { get; set; }
        public int QuantidadeDisponivel { get; set; }
        public int IdAutor { get; set; }
    }

    public class AdicionarLivroRequestValidator : AbstractValidator<AdicionarLivroRequest>
    {
        public AdicionarLivroRequestValidator()
        {
            RuleFor(r => r.Titulo)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .NotNull()
                .WithMessage("Nome não pode ser nulo.");
        }
    }
}
