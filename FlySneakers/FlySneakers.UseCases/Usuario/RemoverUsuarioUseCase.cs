using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverUsuarioUseCase : IRemoverUsuarioUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public RemoverUsuarioUseCase(IUsuarioRepository usuarioRepository, IUsuarioDadosRepository usuarioDadosRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public int Execute(int codigo)
        {
            int resultDados;
            try
            {
                var result = this.usuarioRepository.RemoverDadosUsuario(codigo);
                resultDados = this.usuarioRepository.RemoverUsuario(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return resultDados;
        }
    }
}
