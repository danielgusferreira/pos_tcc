using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.Repositories
{
    public interface IUsuarioRepository
    {
        UsuarioLogadoDto VerificarLogin(LoginDto login);
        int CadastrarUsuario(Usuario usuario);
        int CadastrarDadosUsuario(UsuarioDados usuario);
    }
}
