using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using System;

namespace FlySneakers.UseCases
{
    public class VerificarExistenciaComentarioUseCase : IVerificarExistenciaComentarioUseCase
    {
        private readonly IComentarioRepository ComentarioRepository;

        public VerificarExistenciaComentarioUseCase(IComentarioRepository comentarioRepository)
        {
            this.ComentarioRepository = comentarioRepository;
        }

        public bool Execute(int codigoUsuario, int codigoProduto)
        {
            bool result;
            try
            {
                result = this.ComentarioRepository.VerificarExistenciaComentario(codigoUsuario, codigoProduto);
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
