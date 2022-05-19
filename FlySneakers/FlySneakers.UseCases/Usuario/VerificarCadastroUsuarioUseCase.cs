using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;

namespace FlySneakers.UseCases.Usuario
{
    public class VerificarCadastroUsuarioUseCase : IVerificarCadastroUsuarioUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public VerificarCadastroUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public bool Execute(string email)
        {
            return this.usuarioRepository.VerificarCadastroUsuario(email);
        }
    }
}
