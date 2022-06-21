using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.UseCase
{
    public interface IObterUsuariosUseCase
    {
        IEnumerable<UsuariosDto> Execute(ObterUsuariosDto obterUsuariosDto);
    }
}
