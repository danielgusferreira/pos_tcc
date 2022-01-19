using FlySneakers.Api.Models;
using FlySneakers.Borders.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace FlySneakers.Api.Controllers
{
    [ApiController]
    [Route("api/UsuarioDados-dados")]
    public class UsuarioDadosController : BaseController
    {
        private readonly IActionResultConverter actionResultConverter;

        public UsuarioDadosController(IActionResultConverter actionResultConverter)
        {
            this.actionResultConverter = actionResultConverter;
        }

        /// <summary>
        /// Obter dados usuarios
        /// </summary>
        /// <response code="200">Dados usuarios retornados</response>
        /// <response code="400">Dados usuarios não encontrados</response>
        /// <response code="500">Erro inesperado</response>
        [HttpGet]
        public ActionResult<IEnumerable<UsuarioDados>> ObterUsuarioDados()
        {
            var listaUsuarioDadoss = new List<UsuarioDados>
            {
                new UsuarioDados
                {
                    Codigo = 1,
                    CodigoUsuario = 1,
                    Cpf = "10336391233",
                    DataNascimento = DateTime.Now.AddDays(-1000),
                    Telefone = "31973095962",
                    Cep = 32260450,
                    Endereco = "Rua ABC",
                    Numero = "204",
                    Complemento = "Casa",
                    Bairro = "Centro",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                },
                new UsuarioDados
                {
                    Codigo = 2,
                    CodigoUsuario = 2,
                    Cpf = "65445334212",
                    DataNascimento = DateTime.Now.AddDays(-2000),
                    Telefone = "33999876543",
                    Cep = 32260000,
                    Endereco = "Rua DEF",
                    Numero = "460",
                    Complemento = "Bloco C - Apt 202",
                    Bairro = "Floresta",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                },
                new UsuarioDados
                {
                    Codigo = 3,
                    CodigoUsuario = 3,
                    Cpf = "12345678654",
                    DataNascimento = DateTime.Now.AddDays(-5000),
                    Telefone = "31973095990",
                    Cep = 32260430,
                    Endereco = "Rua Matriz",
                    Numero = "1500",
                    Complemento = "Casa",
                    Bairro = "Buritis",
                    Cidade = "Belo Horizonte",
                    Uf = "MG"
                },
            };

            return Ok(listaUsuarioDadoss);
        }

        /// <summary>
        /// Cadastrar dados usuario
        /// </summary>
        /// <response code="200">Dados usuario cadastrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPost]
        public ActionResult<UsuarioDados> CadastrarUsuarioDados([FromBody] UsuarioDados UsuarioDados)
        {
            UsuarioDados.Codigo = 3;
            return Ok(UsuarioDados);
        }

        /// <summary>
        /// Alterar dados usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Dados usuario alterado</response>
        /// <response code="400">Dados usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpPut("{idUsuarioDados}")]
        public ActionResult<UsuarioDados> AlterarUsuarioDados(int idUsuarioDados, [FromBody] UsuarioDados UsuarioDados)
        {
            return Ok(UsuarioDados);
        }

        /// <summary>
        /// Remover dados usuario a partir do ID informado
        /// </summary>
        /// <response code="200">Dados usuario removido</response>
        /// <response code="400">Dados usuario não encontrado</response>
        /// <response code="500">Erro inesperado</response>
        [HttpDelete("{IdUsuarioDados}")]
        public ActionResult<int> RemoverUsuarioDados(int idUsuarioDados)
        {
            return Ok(idUsuarioDados);
        }

    }
}
