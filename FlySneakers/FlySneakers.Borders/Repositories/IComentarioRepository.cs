using FlySneakers.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Borders.Repositories
{
    public interface IComentarioRepository
    {
        Task<IEnumerable<Comentario>> ObterComentarios();
        int CadastrarComentario(Comentario comentario);
        int AtualizarComentario(Comentario comentario);
        int RemoverComentario(int codigo);
    }
}
