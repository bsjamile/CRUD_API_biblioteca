using FluentValidation;

namespace WoMakersCode.Biblioteca.Application.Models.AdicionarAutor
{
    public class AdicionarAutorRequest
    {
        public string Nome { get; set; }
    }

    public class AdicionarUsuarioRequestValidator : AbstractValidator<AdicionarAutorRequest>
    {
        public AdicionarUsuarioRequestValidator()
        {
            RuleFor(r => r.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser vazio")
                .NotNull()
                .WithMessage("Nome não pode ser nulo.");
        }
    }
}
