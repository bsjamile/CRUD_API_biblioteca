using System.Threading.Tasks;

namespace WoMakersCode.Biblioteca.Application.UseCases
{
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> ExecuteAsync(TRequest request);
    }

}
