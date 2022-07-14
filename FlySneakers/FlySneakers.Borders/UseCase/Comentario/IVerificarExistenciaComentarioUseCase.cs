using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IVerificarExistenciaComentarioUseCase
    {
        bool Execute(int codigoUsuario, int codigoProduto);
    }
}
