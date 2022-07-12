using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.ListarEmprestimo;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class ListarEmprestimoUseCase : IUseCaseAsync<ListarEmprestimoRequest, List<ListarEmprestimoResponse>>
    {
        public readonly IEmprestimoRepository _repository;
        public readonly IMapper _mapper;
        public ListarEmprestimoUseCase(IEmprestimoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ListarEmprestimoResponse>> ExecuteAsync(ListarEmprestimoRequest request)
        {
            var emprestimos = await _repository.ListarTodos();
            var emprestimosResponse = _mapper.Map<List<ListarEmprestimoResponse>>(emprestimos);

            return emprestimosResponse;

        }
    }
}
