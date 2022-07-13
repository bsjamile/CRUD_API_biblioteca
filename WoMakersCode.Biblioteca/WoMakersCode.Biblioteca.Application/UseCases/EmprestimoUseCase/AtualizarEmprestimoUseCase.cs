using AutoMapper;
using System;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AtualizarEmprestimo;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class AtualizarEmprestimoUseCase : IUseCaseAsync<AtualizarEmprestimoRequest, AtualizarEmprestimoResponse>
    {
        private readonly IEmprestimoRepository _repository;
        public readonly IMapper _mapper;
        public AtualizarEmprestimoUseCase(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AtualizarEmprestimoResponse> ExecuteAsync(AtualizarEmprestimoRequest request)
        {
            var emp = _mapper.Map<Emprestimo>(request);

            var emprestimo = await _repository.ListarPorIdParaAtualizarEmprestimo(emp.Id);

            emprestimo.DataDevolucao = DateTime.Now;

            await _repository.Atualizar(emprestimo);

            return new AtualizarEmprestimoResponse();

        }
    }
}
