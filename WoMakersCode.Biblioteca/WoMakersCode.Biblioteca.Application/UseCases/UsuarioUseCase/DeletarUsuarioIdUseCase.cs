using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.DeletarUsuario;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase
{
    public class DeletarUsuarioIdUseCase : IUseCaseAsync<int, DeletarUsuarioIdResponse>
    {
        public readonly IUsuarioRepository _repository;
        public readonly IMapper _mapper;
        public DeletarUsuarioIdUseCase(IUsuarioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<DeletarUsuarioIdResponse> ExecuteAsync(int request)
        {
            var resposta = _repository.Excluir(request);

            var response = _mapper.Map<DeletarUsuarioIdResponse>(resposta);

            return response;
        }

    }
}
