using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IUsuarioRepository
    {
        IEnumerable<UsuariosDto> ObterUsuarios(ObterUsuariosDto obterUsuariosDto);
        UsuarioLogadoDto VerificarLogin(LoginDto login);
        bool VerificarCadastroUsuario(string email);
        int CadastrarUsuario(Usuario usuario);
        int CadastrarDadosUsuario(UsuarioDados usuario);
        int AtualizarUsuario(UsuariosDto usuario);
        int AtualizarDadosUsuario(UsuariosDto usuario);
        int RemoverUsuario(int codigo);
        int RemoverDadosUsuario(int codigo); 
    }
}
