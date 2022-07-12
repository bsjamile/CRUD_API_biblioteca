using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AtualizarEmprestimo;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class AtualizarEmprestimoUseCase : IUseCaseAsync<AtualizarEmprestimoRequest, AtualizarEmprestimoResponse>
    {
        private readonly IEmprestimoRepository _repository;
        public AtualizarEmprestimoUseCase(IEmprestimoRepository repository)
        {
            _repository = repository;
        }
        public async Task<AtualizarEmprestimoResponse> ExecuteAsync(AtualizarEmprestimoRequest request)
        {
            var emprestimo = await _repository.ListarPorIdParaAtualizarEmprestimo(request.Id);

            emprestimo.DataDevolucao = DateTime.Now;

            await _repository.Atualizar(emprestimo);

            return new AtualizarEmprestimoResponse();

        }
    }
}
