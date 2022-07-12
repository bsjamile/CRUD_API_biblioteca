using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarLivro;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.DeletarEmprestimo;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class DeletarEmprestimoIdUseCase : IUseCaseAsync<DeletarEmprestimoIdRequest, DeletarEmprestimoIdResponse>
    {
        public readonly IEmprestimoRepository _repository;
        public DeletarEmprestimoIdUseCase(IEmprestimoRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletarEmprestimoIdResponse> ExecuteAsync(DeletarEmprestimoIdRequest request)
        {
            /* public async Task<DeletarEmprestimoIdResponse> ExecuteAsync(DeletarEmprestimoIdRequest request)
                 var emprestimo = await _repository.ListarPorId(request.Id);
                 await _repository.Excluir(emprestimo);
                 return new DeletarEmprestimoIdResponse();*/

            var emprestimo = await _repository.ListarPorId(request.Id);

            await _repository.Excluir(emprestimo);

            return new DeletarEmprestimoIdResponse(); 
        }

    }
}
