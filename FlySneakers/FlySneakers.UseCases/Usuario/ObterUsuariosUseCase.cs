using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System.Collections.Generic;

namespace FlySneakers.UseCases.Usuario
{
    public class ObterUsuariosUseCase : IObterUsuariosUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public ObterUsuariosUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public IEnumerable<UsuariosDto> Execute(ObterUsuariosDto obterUsuariosDto)
        {
           return usuarioRepository.ObterUsuarios(obterUsuariosDto);
        }
    }
}
