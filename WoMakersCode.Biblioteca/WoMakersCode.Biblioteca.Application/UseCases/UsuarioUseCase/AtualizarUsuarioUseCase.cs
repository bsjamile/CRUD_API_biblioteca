using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Usuario.AtualizarUsuario;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase
{
    public class AtualizarUsuarioUseCase : IUseCaseAsync<AtualizarUsuarioRequest, AtualizarUsuarioResponse>
    {
        public readonly IUsuarioRepository _repository;
        public readonly IMapper _mapper;
        public AtualizarUsuarioUseCase(IUsuarioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AtualizarUsuarioResponse> ExecuteAsync(AtualizarUsuarioRequest request)
        {
            if (request == null)
                return null;

            var usuario = _mapper.Map<Usuario>(request);

            await _repository.Atualizar(usuario);

            return new AtualizarUsuarioResponse();
        }
    }
}
