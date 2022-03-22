using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface ICadastrarUsuarioUseCase
    {
        UsuarioLogadoDto Execute(Usuario usuario);
    }
}
