using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IComentarioRepository
    {
        IEnumerable<Comentario> ObterComentarios(int codigo);
        int CadastrarComentario(Comentario comentario);
        int AtualizarComentario(Comentario comentario);
        int RemoverComentario(int codigo);
    }
}
