using FlySneakers.Borders.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FlySneakers.Borders.Repositories
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<MeioPagamento>> ObterFormaPagamentos();
        int CadastrarFormaPagamento(MeioPagamento marca);
        int AtualizarFormaPagamento(MeioPagamento marca);
        int RemoverFormaPagamento(int codigo);
    }
}
