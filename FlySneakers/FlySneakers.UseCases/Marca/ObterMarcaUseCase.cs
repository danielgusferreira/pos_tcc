using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;
using System.Collections.Generic;

namespace FlySneakers.UseCases
{
    public class ObterMarcaUseCase : IObterMarcaUseCase
    {
        private readonly IMarcasRepository MarcaRepository;

        public ObterMarcaUseCase(IMarcasRepository MarcaRepository)
        {
            this.MarcaRepository = MarcaRepository;
        }

        public IEnumerable<Marca> Execute()
        {
            IEnumerable<Marca> result = null;
            try
            {
                result = this.MarcaRepository.ObterMarcas();
            }
            catch (Exception e)
            {
                var a = e;
                throw e;
            }

            return result;
        }
    }
}
