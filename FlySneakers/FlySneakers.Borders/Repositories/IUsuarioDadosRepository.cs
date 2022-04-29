using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.Repositories
{
    public interface IUsuarioDadosRepository
    {
        UsuarioDados ObterDadosUsuario(int codigo);
    }
}
