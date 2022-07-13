using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.DeletarLivro;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase
{
    public class DeletarLivroIdUseCase : IUseCaseAsync<DeletarLivroIdRequest, DeletarLivroIdResponse>
    {
        public readonly ILivroRepository _repository;
        public DeletarLivroIdUseCase(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<DeletarLivroIdResponse> ExecuteAsync(DeletarLivroIdRequest request)
        {
            var livro = await _repository.ListarPorId(request.Id);
            await _repository.Excluir(livro);
            return new DeletarLivroIdResponse();
        }

    }
}
