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
    public class ObterUsuarioDadosUseCase : IObterUsuarioDadosUseCase
    {
        private readonly IUsuarioDadosRepository usuarioDadosRepository;
        private Borders.Models.UsuarioDados result;

        public ObterUsuarioDadosUseCase(IUsuarioDadosRepository usuarioDadosRepository)
        {
            this.usuarioDadosRepository = usuarioDadosRepository;
        }

        public Borders.Models.UsuarioDados Execute(int codigo)
        {
            try
            {
                result = this.usuarioDadosRepository.ObterDadosUsuario(codigo);
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
