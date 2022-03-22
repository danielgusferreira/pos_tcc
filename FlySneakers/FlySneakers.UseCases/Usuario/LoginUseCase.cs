using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases.Usuario
{
    public class LoginUseCase : ILogarUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IUsuarioRepository usuarioRepository;

        //Criando construtor passando o repositorio e o validador
        public LoginUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public UsuarioLogadoDto Execute(LoginDto request)
        {
            UsuarioLogadoDto result = null;
            try
            {
                result = this.usuarioRepository.VerificarLogin(request);
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao criar cliente");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
