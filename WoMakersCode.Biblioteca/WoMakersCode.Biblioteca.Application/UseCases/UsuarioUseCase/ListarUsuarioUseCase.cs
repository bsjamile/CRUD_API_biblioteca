using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Usuario.ListarUsuario;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase
{
    public class ListarUsuarioUseCase : IUseCaseAsync<ListarUsuarioRequest, List<ListarUsuarioResponse>>
    {
        public readonly IUsuarioRepository _repository;
        public readonly IMapper _mapper;
        public ListarUsuarioUseCase(IUsuarioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ListarUsuarioResponse>> ExecuteAsync(ListarUsuarioRequest request)
        {
            var usuarios = await _repository.ListarTodos();
            var usuariosResponse = _mapper.Map<List<ListarUsuarioResponse>>(usuarios);

            return usuariosResponse;

        }
    }
}
