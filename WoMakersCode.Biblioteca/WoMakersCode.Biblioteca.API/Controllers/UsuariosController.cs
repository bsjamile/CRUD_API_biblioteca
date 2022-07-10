using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.DeletarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.AtualizarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.ListarUsuario;
using WoMakersCode.Biblioteca.Application.UseCases;

namespace WoMakersCode.Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUseCaseAsync<int, ListarUsuarioResponse> _getIdUseCase;
        private readonly IUseCaseAsync<ListarUsuarioRequest, List<ListarUsuarioResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse> _postUseCase;
        private readonly IUseCaseAsync<AtualizarUsuarioRequest, AtualizarUsuarioResponse> _putUseCase;
        private readonly IUseCaseAsync<int, DeletarUsuarioIdResponse> _deleteUseCase;

        public UsuariosController(IUseCaseAsync<int, ListarUsuarioResponse> getIdUseCase,
            IUseCaseAsync<ListarUsuarioRequest, List<ListarUsuarioResponse>> getAllUseCase,
            IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse> postUseCase,
            IUseCaseAsync<AtualizarUsuarioRequest, AtualizarUsuarioResponse> putUseCase,
            IUseCaseAsync<int, DeletarUsuarioIdResponse> deleteUseCase)
        {
            _getIdUseCase = getIdUseCase;
            _getAllUseCase = getAllUseCase;
            _postUseCase = postUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ListarUsuarioResponse>> Get(int id)
        {
            var response = await _getIdUseCase.ExecuteAsync(id);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarUsuarioResponse>>> Get([FromQuery] ListarUsuarioRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }

        [HttpPost]
        public async Task<ActionResult<AdicionarUsuarioResponse>> Post([FromBody] AdicionarUsuarioRequest request)
        {
            return await _postUseCase.ExecuteAsync(request);
        }

        [HttpPut]
        public async Task<ActionResult<AtualizarUsuarioResponse>> Put([FromBody] AtualizarUsuarioRequest usuario)
        {
            await _putUseCase.ExecuteAsync(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletarUsuarioIdResponse>> Delete(int id)
        {
            var usuarioToDelete = await _deleteUseCase.ExecuteAsync(id);

            if (usuarioToDelete == null)
                return new NotFoundObjectResult("Não encontrado");

            return NoContent();
        }
    }
}
