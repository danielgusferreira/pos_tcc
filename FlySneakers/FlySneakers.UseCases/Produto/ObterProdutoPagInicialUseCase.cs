using FlySneakers.Borders.Dto;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase.Produto;
using FlySneakers.Shared.Shared;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace FlySneakers.UseCases
{
    public class ObterProdutoPagInicialUseCase : IObterProdutoPagInicialUseCase
    {
        //Instancio variaveis que estão sendo utilizadas
        private readonly IProdutoRepository produtoRepository;

        //Criando construtor passando o repositorio e o validador
        public ObterProdutoPagInicialUseCase(IProdutoRepository produtoRepository)
        {
            this.produtoRepository = produtoRepository;
        }

        public IEnumerable<ProdutoPagInicialDto> Execute(int codigoCategoria, int codigoMarca)
        {
            IEnumerable<ProdutoPagInicialDto> result = null;
            try
            {
                result = this.produtoRepository.ObterProdutosPagInicial(codigoCategoria, codigoMarca);
            }
            catch (Exception ex)
            {
                throw ex;
                //ErrorMessage errMsg = new ErrorMessage("00.01", "Error ao adicionar produto ao carrinho");
                //var errorData = e.Data?.OfType<DictionaryEntry>().ToDictionary(kv => kv.Key.ToString(), kv => kv.Value?.ToString());
            }

            return result;
        }
    }
}
