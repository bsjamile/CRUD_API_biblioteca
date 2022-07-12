using AutoMapper;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AdicionarEmprestimo;
using WoMakersCode.Biblioteca.Core.Entities;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase
{
    public class AdicionarEmprestimoUseCase : IUseCaseAsync<AdicionarEmprestimoRequest, AdicionarEmprestimoResponse>
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IMapper _mapper;

        public AdicionarEmprestimoUseCase(IEmprestimoRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<AdicionarEmprestimoResponse> ExecuteAsync(AdicionarEmprestimoRequest request)
        {
            if (request == null)
                return null;

            var emprestimo = _mapper.Map<Emprestimo>(request);

            await _repository.Inserir(emprestimo);

            return new AdicionarEmprestimoResponse();
        }
    }
}
