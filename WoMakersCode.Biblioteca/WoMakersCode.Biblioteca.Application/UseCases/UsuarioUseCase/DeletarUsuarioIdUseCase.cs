using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.DeletarUsuario;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase
{
    public class DeletarUsuarioIdUseCase : IUseCaseAsync<DeletarUsuarioIdRequest, DeletarUsuarioIdResponse>
    {
        public readonly IUsuarioRepository _repository;
        public DeletarUsuarioIdUseCase(IUsuarioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<DeletarUsuarioIdResponse> ExecuteAsync(DeletarUsuarioIdRequest request)
        {
            var usuario = await _repository.ListarPorId(request.Id);
            await _repository.Excluir(usuario);
            return new DeletarUsuarioIdResponse();
        }

    }
}
