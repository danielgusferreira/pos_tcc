using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterUsuarioDadosUseCase
    {
        UsuarioDados Execute(int codigo);
    }
}
