using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterCategoriaUseCase
    {
        IEnumerable<Categoria> Execute();
    }
}
