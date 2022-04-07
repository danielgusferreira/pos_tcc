using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases.Usuario
{
    public class CadastrarDadosUsuarioUseCase : ICadastrarDadosUsuarioUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public CadastrarDadosUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public int Execute(Borders.Models.UsuarioDados request)
        {
            int result = 0;
            try
            {
                result = this.usuarioRepository.CadastrarDadosUsuario(request);
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao inserir dados usuario");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
