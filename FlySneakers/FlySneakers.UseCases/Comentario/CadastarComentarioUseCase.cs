using FlySneakers.Borders.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class CadastarComentarioUseCase : ICadastarComentarioUseCase
    {
        private readonly IComentarioRepository comentarioRepository;

        public CadastarComentarioUseCase(IComentarioRepository comentarioRepository)
        {
            this.comentarioRepository = comentarioRepository;
        }

        public int Execute(Comentario comentario)
        {
            int result = 0;
            try
            {
                result = this.comentarioRepository.CadastrarComentario(comentario);
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}
