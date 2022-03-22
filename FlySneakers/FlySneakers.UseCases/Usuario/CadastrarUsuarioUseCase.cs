using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Borders.Models;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases.Usuario
{
    public class CadastrarUsuarioUseCase : ICadastrarUsuarioUseCase
    {
        private readonly IUsuarioRepository usuarioRepository;

        public CadastrarUsuarioUseCase(IUsuarioRepository usuarioRepository)
        {
            this.usuarioRepository = usuarioRepository;
        }

        public UsuarioLogadoDto Execute(Borders.Models.Usuario request)
        {
            var result = new UsuarioLogadoDto { };
            try
            {
                var insercao = this.usuarioRepository.CadastrarUsuario(request);

                if (insercao != 0)
                {
                    result.Nome = request.Nome;
                    result.Email = request.Email;
                    result.perfil = request.Tipo;
                }              
            }
            catch (Exception e)
            {
                ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao criar usuario");
                var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
