using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Borders.Models;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Linq;

namespace FlySneakers.UseCases.UsuarioDados
{
    public class ValidarUsuarioDadosUseCase : IValidarUsuarioDadosUseCase
    {
        private readonly IUsuarioDadosRepository usuarioDadosRepository;

        public ValidarUsuarioDadosUseCase(IUsuarioDadosRepository usuarioDadosRepository)
        {
            this.usuarioDadosRepository = usuarioDadosRepository;
        }

        public int Execute(int codigo)
        {
            int result = 0;
            try
            {
                result = this.usuarioDadosRepository.VerificarDados(codigo);
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
