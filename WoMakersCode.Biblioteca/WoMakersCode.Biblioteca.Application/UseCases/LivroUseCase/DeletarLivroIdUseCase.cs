using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarLivro;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class DeletarLivroIdUseCase : IUseCaseAsync<int, DeletarLivroIdResponse>
    {
        public readonly ILivroRepository _repository;
        public readonly IMapper _mapper;
        public DeletarLivroIdUseCase(ILivroRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeletarLivroIdResponse> ExecuteAsync(int request)
        {
            var resposta = _repository.Excluir(request);

            var response = _mapper.Map<DeletarLivroIdResponse>(resposta);

            return response;
        }

    }
}
