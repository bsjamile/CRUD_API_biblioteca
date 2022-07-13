using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.ListarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class ListarEmprestimoIdUseCase : IUseCaseAsync<int, ListarEmprestimoResponse>
    {
        public readonly IEmprestimoRepository _repository;
        public readonly IMapper _mapper;
        public ListarEmprestimoIdUseCase(IEmprestimoRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListarEmprestimoResponse> ExecuteAsync(int request)
        {
            var resposta = await _repository.ListarPorId(request);

            var emprestimosResponse = _mapper.Map<ListarEmprestimoResponse>(resposta);

            return emprestimosResponse;

        }
    }
}
