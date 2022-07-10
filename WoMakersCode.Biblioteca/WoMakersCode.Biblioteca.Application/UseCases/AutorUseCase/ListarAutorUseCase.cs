using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.ListarAutor;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class ListarAutorUseCase : IUseCaseAsync<ListarAutorRequest, List<ListarAutorResponse>>
    {
        public readonly IAutorRepository _repository;
        public readonly IMapper _mapper;
        public ListarAutorUseCase(IAutorRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ListarAutorResponse>> ExecuteAsync(ListarAutorRequest request)
        {
            var livros = await _repository.ListarTodos();
            var livrosResponse = _mapper.Map<List<ListarAutorResponse>>(livros);

            return livrosResponse;

        }
    }
}
