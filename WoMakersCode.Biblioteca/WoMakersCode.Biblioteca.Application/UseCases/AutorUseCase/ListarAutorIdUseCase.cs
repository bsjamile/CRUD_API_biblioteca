using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.ListarAutor;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class ListarAutorIdUseCase : IUseCaseAsync<int, ListarAutorResponse>
    {
        public readonly IAutorRepository _repository;
        public readonly IMapper _mapper;
        public ListarAutorIdUseCase(IAutorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListarAutorResponse> ExecuteAsync(int request)
        {
            var resposta = await _repository.ListarPorId(request);

            var livrosResponse = _mapper.Map<ListarAutorResponse>(resposta);

            return livrosResponse;
        }
    }
}
