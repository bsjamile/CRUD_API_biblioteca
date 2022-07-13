using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.Autor.AtualizarAutor;
using WoMakersCode.Biblioteca.Application.Models.Autor.DeletarAutor;
using WoMakersCode.Biblioteca.Application.Models.DeletarAutor;
using WoMakersCode.Biblioteca.Application.Models.ListarAutor;
using WoMakersCode.Biblioteca.Application.UseCases;

namespace WoMakersCode.Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly IUseCaseAsync<int, ListarAutorResponse> _getIdUseCase;
        private readonly IUseCaseAsync<ListarAutorRequest, List<ListarAutorResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<AdicionarAutorRequest, AdicionarAutorResponse> _postUseCase;
        private readonly IUseCaseAsync<AtualizarAutorRequest, AtualizarAutorResponse> _putUseCase;
        private readonly IUseCaseAsync<DeletarAutorIdRequest, DeletarAutorIdResponse> _deleteUseCase;
        public AutoresController(IUseCaseAsync<int, ListarAutorResponse> getIdUseCase,
            IUseCaseAsync<ListarAutorRequest, List<ListarAutorResponse>> getAllUseCase,
            IUseCaseAsync<AdicionarAutorRequest, AdicionarAutorResponse> postUseCase,
            IUseCaseAsync<AtualizarAutorRequest, AtualizarAutorResponse> putUseCase,
            IUseCaseAsync<DeletarAutorIdRequest, DeletarAutorIdResponse> deleteUseCase)
        {
            _getIdUseCase = getIdUseCase;            
            _getAllUseCase = getAllUseCase;
            _postUseCase = postUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ListarAutorResponse>> Get(int id)
        {
            var response = await _getIdUseCase.ExecuteAsync(id);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarAutorResponse>>> Get([FromQuery] ListarAutorRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);

        }

        [HttpPost]
        public async Task<ActionResult<AdicionarAutorResponse>> Post([FromBody] AdicionarAutorRequest request)
        {
            return await _postUseCase.ExecuteAsync(request);
        }

        [HttpPut]
        public async Task<ActionResult<AtualizarAutorResponse>> Put([FromBody] AtualizarAutorRequest autor)
        {
            return await _putUseCase.ExecuteAsync(autor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletarAutorIdResponse>> Delete([FromRoute] int id)
        {
            return await _deleteUseCase.ExecuteAsync(new DeletarAutorIdRequest() { Id = id });
        }
    }
}
