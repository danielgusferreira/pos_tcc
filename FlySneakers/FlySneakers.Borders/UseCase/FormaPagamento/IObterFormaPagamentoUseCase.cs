using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterFormaPagamentoUseCase
    {
        IEnumerable<MeioPagamento> Execute();
    }
}
