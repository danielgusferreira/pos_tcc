using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IFormaPagamentoRepository
    {
        IEnumerable<MeioPagamento> ObterFormaPagamentos();
        int CadastrarFormaPagamento(MeioPagamento marca);
        int AtualizarFormaPagamento(MeioPagamento marca);
        int RemoverFormaPagamento(int codigo);
    }
}
