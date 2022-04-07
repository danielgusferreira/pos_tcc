using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.UseCase.Produto
{
    public interface IObterProdutoDetalhesUseCase
    {
        ProdutoDetalhesDto Execute(int codigo);
    }
}
