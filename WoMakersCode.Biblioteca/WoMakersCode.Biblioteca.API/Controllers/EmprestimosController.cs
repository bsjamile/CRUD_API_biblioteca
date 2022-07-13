using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AdicionarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AtualizarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.DeletarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.ListarEmprestimo;
using WoMakersCode.Biblioteca.Application.UseCases;

namespace WoMakersCode.Biblioteca.API.Controllers
{
    [ApiController]
    [Route("api/emprestimos")]
    public class EmprestimosController : ControllerBase
    {
        private readonly IUseCaseAsync<int, ListarEmprestimoResponse> _getIdUseCase;
        private readonly IUseCaseAsync<ListarEmprestimoRequest, List<ListarEmprestimoResponse>> _getAllUseCase;
        private readonly IUseCaseAsync<AdicionarEmprestimoRequest, AdicionarEmprestimoResponse> _postUseCase;
        private readonly IUseCaseAsync<AtualizarEmprestimoRequest, AtualizarEmprestimoResponse> _putUseCase;
        private readonly IUseCaseAsync<DeletarEmprestimoIdRequest, DeletarEmprestimoIdResponse> _deleteUseCase;
        public EmprestimosController(IUseCaseAsync<int, ListarEmprestimoResponse> getIdUseCase,
            IUseCaseAsync<ListarEmprestimoRequest, List<ListarEmprestimoResponse>> getAllUseCase,
            IUseCaseAsync<AdicionarEmprestimoRequest, AdicionarEmprestimoResponse> postUseCase,
            IUseCaseAsync<AtualizarEmprestimoRequest, AtualizarEmprestimoResponse> putUseCase,
            IUseCaseAsync<DeletarEmprestimoIdRequest, DeletarEmprestimoIdResponse> deleteUseCase)
        {
            _getIdUseCase = getIdUseCase;
            _getAllUseCase = getAllUseCase;
            _postUseCase = postUseCase;
            _putUseCase = putUseCase;
            _deleteUseCase = deleteUseCase;
        }

        [HttpGet("id")]
        public async Task<ActionResult<ListarEmprestimoResponse>> Get(int id)
        {
            var response = await _getIdUseCase.ExecuteAsync(id);
            if (response == null)
                return new NotFoundObjectResult("Não encontrado");

            return new OkObjectResult(response);
        }

        [HttpGet]
        public async Task<ActionResult<List<ListarEmprestimoResponse>>> Get([FromQuery] ListarEmprestimoRequest request)
        {
            return await _getAllUseCase.ExecuteAsync(request);

        }

        [HttpPost]
        public async Task<ActionResult<AdicionarEmprestimoResponse>> Post([FromBody] AdicionarEmprestimoRequest request)
        {
            return await _postUseCase.ExecuteAsync(request);
        }

        [HttpPut("devolucao-livro/{id:int}")]
        public async Task<ActionResult<AtualizarEmprestimoResponse>> Put([FromRoute] int id)
        {
            return await _putUseCase.ExecuteAsync(new AtualizarEmprestimoRequest() { Id = id });
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult<DeletarEmprestimoIdResponse>> Delete([FromRoute] int id)
        {
            return await _deleteUseCase.ExecuteAsync(new DeletarEmprestimoIdRequest() { Id = id });
        }
        /*
         * 
         public async Task<ActionResult<DeletarEmprestimoIdResponse>> Delete(int id)
        var emprestimoToDelete = await _deleteUseCase.ExecuteAsync(id);

        if (emprestimoToDelete == null)
            return new NotFoundObjectResult("Não encontrado");

        return NoContent();
        */
    }
}


