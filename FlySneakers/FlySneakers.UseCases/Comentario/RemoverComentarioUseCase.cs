using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class RemoverComentarioUseCase : IRemoverComentarioUseCase
    {
        private readonly IComentarioRepository ComentarioRepository;

        public RemoverComentarioUseCase(IComentarioRepository comentarioRepository)
        {
            this.ComentarioRepository = comentarioRepository;
        }

        public int Execute(int codigo)
        {
            int result;
            try
            {
                result = this.ComentarioRepository.RemoverComentario(codigo);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
