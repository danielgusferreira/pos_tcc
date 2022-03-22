using FlySneakers.Borders.Dto;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterCarrinhoUsuarioUseCase
    {
        IEnumerable<DadosCarrinhoDto> Execute(int codUsuario);
    }
}
