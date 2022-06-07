using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverMarcaUseCase : IRemoverMarcaUseCase
    {
        private readonly IMarcasRepository MarcaRepository;

        public RemoverMarcaUseCase(IMarcasRepository MarcaRepository)
        {
            this.MarcaRepository = MarcaRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.MarcaRepository.RemoverMarca(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
