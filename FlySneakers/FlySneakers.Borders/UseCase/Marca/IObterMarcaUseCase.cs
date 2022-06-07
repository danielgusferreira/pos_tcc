using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterMarcaUseCase
    {
        IEnumerable<Marca> Execute();
    }
}
