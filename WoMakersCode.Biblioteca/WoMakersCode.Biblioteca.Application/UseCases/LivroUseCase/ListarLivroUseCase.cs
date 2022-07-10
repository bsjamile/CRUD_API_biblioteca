using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarLivro;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class ListarLivroUseCase : IUseCaseAsync<ListarLivroRequest, List<ListarLivroResponse>>
    {
        public readonly ILivroRepository _repository;
        public readonly IMapper _mapper;
        public ListarLivroUseCase(ILivroRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ListarLivroResponse>> ExecuteAsync(ListarLivroRequest request)
        {
            var livros = await _repository.ListarTodos();
            var livrosResponse = _mapper.Map<List<ListarLivroResponse>>(livros);

            return livrosResponse;

        }
    }
}
