using System.Threading.Tasks;

namespace FlySneakers.Borders.Shared
{
    public interface IUseCase<tRequest, TResponse>
    {
        UseCaseResponse<TResponse> Execute(tRequest request);
    }
}
