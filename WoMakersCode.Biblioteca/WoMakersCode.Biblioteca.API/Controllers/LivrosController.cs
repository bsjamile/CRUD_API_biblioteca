using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarLivro;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.DeletarLivro;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.AdicionarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.AtualizarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.DeletarLivro;
using WoMakersCode.Biblioteca.Application.UseCases;
using WoMakersCode.Biblioteca.Core.Entities;

namespace WoMakersCode.Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/livros")] //endpoint (ponto final)
    public class LivrosController : ControllerBase
    {
        private readonly IUseCaseAsync<int, ListarLivroResponse> _getIdUseCase;
        private readonly IUseCaseAsync<ListarLivroRequest, List<ListarLivroResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<AdicionarLivroRequest, AdicionarLivroResponse> _postUseCase;
        private readonly IUseCaseAsync<AtualizarLivroRequest, AtualizarLivroResponse> _putUseCase;
        private readonly IUseCaseAsync<DeletarLivroIdRequest, DeletarLivroIdResponse> _deleteUseCase;
        public LivrosController(IUseCaseAsync<int, ListarLivroResponse> getIdUseCase,
            IUseCaseAsync<ListarLivroRequest, List<ListarLivroResponse>> getAllUseCase,
            IUseCaseAsync<AdicionarLivroRequest, AdicionarLivroResponse> postUseCase,
            IUseCaseAsync<AtualizarLivroRequest, AtualizarLivroResponse> putUseCase,
            IUseCaseAsync<DeletarLivroIdRequest, DeletarLivroIdResponse> deleteUseCase)
        {
            _getIdUseCase = getIdUseCase;
            _getAllUseCase = getAllUseCase;
            _postUseCase = postUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ListarLivroResponse>> Get(int id)
        {
            var response = await _getIdUseCase.ExecuteAsync(id);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarLivroResponse>>> Get([FromQuery] ListarLivroRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);
        }

        [HttpPost]
        public async Task<ActionResult<AdicionarLivroResponse>> Post([FromBody] AdicionarLivroRequest request)
        {
            return await _postUseCase.ExecuteAsync(request);
        }

        [HttpPut]
        public async Task<ActionResult<AtualizarLivroResponse>> Put([FromBody] AtualizarLivroRequest livro)
        {
            await _putUseCase.ExecuteAsync(livro);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<DeletarLivroIdResponse>> Delete([FromRoute] int id)
        {
            return await _deleteUseCase.ExecuteAsync(new DeletarLivroIdRequest() { Id = id });
        }
    }
}

