using System.Threading.Tasks;

namespace FlySneakers.Borders.Shared
{
    public interface IUseCase<tRequest, TResponse>
    {
        Task<UseCaseResponse<TResponse>> Execute(tRequest request);
    }
}
