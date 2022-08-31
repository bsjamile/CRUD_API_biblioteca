using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosEmEmprestimo;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.RelatorioUseCase
{
    public class RelatorioLivrosEmEmprestimoUseCase : IUseCaseAsync<LivrosEmEmprestimoRequest, List<LivrosEmEmprestimoResponse>>
    {
        public readonly IRelatorioRepository _repository;
        public readonly IMapper _mapper;

        public RelatorioLivrosEmEmprestimoUseCase(IRelatorioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LivrosEmEmprestimoResponse>> ExecuteAsync(LivrosEmEmprestimoRequest request)
        {
            var emprestimos = await _repository.RelatorioLivrosEmprestados(request.DataEmprestimo, request.DataDevolucao);
            var emprestimosResponse = _mapper.Map<List<LivrosEmEmprestimoResponse>>(emprestimos);

            return emprestimosResponse;
        }
    }
}
