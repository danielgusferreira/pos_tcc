using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface ICadastrarDadosUsuarioUseCase
    {
        int Execute(UsuarioDados usuarioDados);
    }
}
