using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class ListarLivroIdUseCase : IUseCaseAsync<int, ListarLivroResponse>
    {
        public readonly ILivroRepository _repository;
        public readonly IMapper _mapper;
        public ListarLivroIdUseCase(ILivroRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListarLivroResponse> ExecuteAsync(int request)
        {
            var resposta = await _repository.ListarPorId(request);

            var livrosResponse = _mapper.Map<ListarLivroResponse>(resposta);

            return livrosResponse;

        }
    }
}
