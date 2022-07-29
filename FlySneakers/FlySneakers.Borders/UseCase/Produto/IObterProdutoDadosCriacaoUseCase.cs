using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase.Produto
{
    public interface IObterProdutoDadosCriacaoUseCase
    {
        IEnumerable<ProdutoSku> Execute(int codigoProduto);
    }
}
