using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.UseCase
{
    public interface ILogarUseCase
    {
        UsuarioLogadoDto Execute(LoginDto loginDto);
    }
}
