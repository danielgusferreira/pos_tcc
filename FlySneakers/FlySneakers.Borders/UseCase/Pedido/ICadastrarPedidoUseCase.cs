﻿using FlySneakers.Borders.Dto;

namespace FlySneakers.Borders.UseCase
{
    public interface ICadastrarPedidoUseCase
    {
        int Execute(CadastrarPedidoDto carrinho);
    }
}
