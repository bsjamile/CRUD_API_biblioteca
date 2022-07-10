using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Usuario.ListarUsuario;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase
{
    public class ListarUsuarioIdUseCase : IUseCaseAsync<int, ListarUsuarioResponse>
    {
        public readonly IUsuarioRepository _repository;
        public readonly IMapper _mapper;
        public ListarUsuarioIdUseCase(IUsuarioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ListarUsuarioResponse> ExecuteAsync(int request)
        {
            var resposta = await _repository.ListarPorId(request);

            var usuariosResponse = _mapper.Map<ListarUsuarioResponse>(resposta);

            return usuariosResponse;
        }
    }
}
