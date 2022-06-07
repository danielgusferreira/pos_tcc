using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterComentarioUseCase
    {
        IEnumerable<Comentario> Execute(int codigo);
    }
}
