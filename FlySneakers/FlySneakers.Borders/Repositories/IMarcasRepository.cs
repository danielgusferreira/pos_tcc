using FlySneakers.Borders.Models;
using System.Collections.Generic;

namespace FlySneakers.Borders.Repositories
{
    public interface IMarcasRepository
    {
        IEnumerable<Marca> ObterMarcas();
        int CadastrarMarca(Marca marca);
        int AtualizarMarca(Marca marca);
        int RemoverMarca(int codigo);
    }
}
