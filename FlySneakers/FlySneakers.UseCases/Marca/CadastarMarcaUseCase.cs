using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastarMarcaUseCase : ICadastarMarcaUseCase
    {
        private readonly IMarcasRepository MarcaRepository;

        public CadastarMarcaUseCase(IMarcasRepository MarcaRepository)
        {
            this.MarcaRepository = MarcaRepository;
        }

        public int Execute(Marca marca)
        {
            int result;
            try
            {
                result = this.MarcaRepository.CadastrarMarca(marca);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
