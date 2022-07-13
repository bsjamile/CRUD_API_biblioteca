using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Autor.DeletarAutor;
using WoMakersCode.Biblioteca.Application.Models.DeletarAutor;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase
{
    public class DeletarAutorIdUseCase : IUseCaseAsync<DeletarAutorIdRequest, DeletarAutorIdResponse>
    {
        public readonly IAutorRepository _repository;
        public DeletarAutorIdUseCase(IAutorRepository repository)
        {
            _repository = repository;
        }
        public async Task<DeletarAutorIdResponse> ExecuteAsync(DeletarAutorIdRequest request)
        {
            var autor = await _repository.ListarPorId(request.Id);
            await _repository.Excluir(autor);
            return new DeletarAutorIdResponse();
        }
    }
}
