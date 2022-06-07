using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface IEditarFormaPagamentoUseCase
    {
        int Execute(MeioPagamento meioPagamento);
    }
}
