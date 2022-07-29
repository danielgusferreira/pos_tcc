using FlySneakers.Borders.Models;

namespace FlySneakers.Borders.UseCase
{
    public interface IAlterarProdutoDadosUseCase
    {
        int Execute(ProdutoSku produtoSku);
    }
}
