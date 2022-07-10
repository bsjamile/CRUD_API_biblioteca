using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Autor.AtualizarAutor;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class AtualizarAutorUseCase : IUseCaseAsync<AtualizarAutorRequest, AtualizarAutorResponse>
    {
        public readonly IAutorRepository _repository;
        public readonly IMapper _mapper;
        public AtualizarAutorUseCase(IAutorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AtualizarAutorResponse> ExecuteAsync(AtualizarAutorRequest request)
        {
            if (request == null)
                return null;

            var autor = _mapper.Map<Autor>(request);

            await _repository.Atualizar(autor);

            return new AtualizarAutorResponse();
        }
    }
}
