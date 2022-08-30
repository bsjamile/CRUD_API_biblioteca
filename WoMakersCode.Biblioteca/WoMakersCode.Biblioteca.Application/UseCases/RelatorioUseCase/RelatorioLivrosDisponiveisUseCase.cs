using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosDisponiveis;
using WoMakersCode.Biblioteca.Core.Repositories;

namespace WoMakersCode.Biblioteca.Application.UseCases.RelatorioUseCase
{
    public class RelatorioLivrosDisponiveisUseCase : IUseCaseAsync<LivrosDisponiveisRequest, List<LivrosDisponiveisResponse>>
    {
        public readonly IRelatorioRepository _repository;
        public readonly IMapper _mapper;

        public RelatorioLivrosDisponiveisUseCase(IRelatorioRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<LivrosDisponiveisResponse>> ExecuteAsync(LivrosDisponiveisRequest request)
        {
            var atrasos = await _repository.RelatorioLivrosDisponiveis(request.TituloLivro, request.NomeAutor);
            var atrasosResponse = _mapper.Map<List<LivrosDisponiveisResponse>>(atrasos);

            return atrasosResponse;
        }
    }
}
