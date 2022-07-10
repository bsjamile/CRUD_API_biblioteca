using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Livro.AdicionarLivro;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class AdicionarLivroUseCase : IUseCaseAsync<AdicionarLivroRequest, AdicionarLivroResponse>
    {
        private readonly ILivroRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarLivroUseCase(ILivroRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AdicionarLivroResponse> ExecuteAsync(AdicionarLivroRequest request)
        {
            if (request == null)
                return null;

            var livro = _mapper.Map<Livro>(request);

            await _repository.Inserir(livro);

            return new AdicionarLivroResponse();
        }
    }
}

