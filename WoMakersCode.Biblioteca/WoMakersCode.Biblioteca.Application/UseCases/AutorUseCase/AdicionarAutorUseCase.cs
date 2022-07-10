using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class AdicionarAutorUseCase : IUseCaseAsync<AdicionarAutorRequest, AdicionarAutorResponse>
    {
        private readonly IAutorRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarAutorUseCase(IAutorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AdicionarAutorResponse> ExecuteAsync(AdicionarAutorRequest request)
        {
            if (request == null)
                return null;

            var autor = _mapper.Map<Autor>(request);

            await _repository.Inserir(autor);

            return new AdicionarAutorResponse();
        }
    }
}

