using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IComentarioRepository
    {
        IEnumerable<ComentarioDto> ObterComentarios(int codigoProduto);
        bool VerificarExistenciaComentario(int codigoUsuario, int codigoProduto);
        int CadastrarComentario(Comentario comentario);
        int AtualizarComentario(Comentario comentario);
        int RemoverComentario(int codigo);
    }
}
