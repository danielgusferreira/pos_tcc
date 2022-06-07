using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class EditarMarcaUseCase : IEditarMarcaUseCase
    {
        private readonly IMarcasRepository MarcaRepository;

        public EditarMarcaUseCase(IMarcasRepository MarcaRepository)
        {
            this.MarcaRepository = MarcaRepository;
        }

        public int Execute(Marca Marca)
        {
            int result;
            try
            {
                result = this.MarcaRepository.AtualizarMarca(Marca);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
