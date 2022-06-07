using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface ICadastarFormaPagamentoUseCase
    {
        int Execute(MeioPagamento meioPagamento);
    }
}
