using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class EditarUsuarioUseCase : IEditarUsuarioUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public EditarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public int Execute(UsuariosDto usuario)
        {
            int result;
            try
            {
                result = this.usuarioRepository.AtualizarDadosUsuario(usuario);
                result = this.usuarioRepository.AtualizarUsuario(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
