using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarAutor;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class DeletarAutorIdUseCase : IUseCaseAsync<int, DeletarAutorIdResponse>
    {
        public readonly IAutorRepository _repository;
        public readonly IMapper _mapper;
        public DeletarAutorIdUseCase(IAutorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<DeletarAutorIdResponse> ExecuteAsync(int request)
        {
            var resposta = _repository.Excluir(request);

            var response = _mapper.Map<DeletarAutorIdResponse>(resposta);

            return response;
        }
    }
}
