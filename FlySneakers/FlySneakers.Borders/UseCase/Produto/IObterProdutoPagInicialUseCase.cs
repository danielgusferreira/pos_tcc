using FlySneakers.Borders.Dto;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase.Produto
{
    public interface IObterProdutoPagInicialUseCase
    {
        IEnumerable<ProdutoPagInicialDto> Execute();
    }
}
