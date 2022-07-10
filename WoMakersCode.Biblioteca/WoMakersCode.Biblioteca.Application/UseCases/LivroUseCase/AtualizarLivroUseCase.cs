using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Livro.AtualizarLivro;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class AtualizarLivroUseCase : IUseCaseAsync<AtualizarLivroRequest, AtualizarLivroResponse>
    {
        public readonly ILivroRepository _repository;
        public readonly IMapper _mapper;
        public AtualizarLivroUseCase(ILivroRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AtualizarLivroResponse> ExecuteAsync(AtualizarLivroRequest request)
        {
            if (request == null)
                return null;

            var livro = _mapper.Map<Livro>(request);

            await _repository.Atualizar(livro);

            return new AtualizarLivroResponse();
        }
    }
}
