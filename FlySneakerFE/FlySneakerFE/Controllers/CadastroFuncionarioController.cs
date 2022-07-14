using FlySneakerFE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlySneakerFE.Controllers
{
    public class CadastroFuncionarioController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<CadastroFuncionarioController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();
        private CadastroFuncionarioDto usuario = new CadastroFuncionarioDto { UsuariosDtos = null };
        private string mensagem = "";

        public CadastroFuncionarioController(ILogger<CadastroFuncionarioController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index(int codigo, string mensagem, string erro, string desc = "")
        {
            if (Request.Cookies["PerfilUsuarioLogado"] != "1" && Request.Cookies["PerfilUsuarioLogado"] != "2")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];
            ViewBag.Mensagem = mensagem;
            ViewBag.Erro = erro;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                var dados = new ObterUsuariosDto { TipoUsuario = new int[] { 1, 2 } };

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:5001/api/usuario/obter", httpContent))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    usuario.UsuariosDtos = JsonConvert.DeserializeObject<IEnumerable<UsuariosDto>>(resultApi);
                }
            }

            if (codigo != 0)
            {
                usuario.Codigo = codigo;
                usuario.Nome = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Nome;
                usuario.Email = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Email;
                usuario.Senha = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Senha;
                usuario.Tipo = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Tipo;
                usuario.Cpf = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Cpf;
                usuario.DataNascimento = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).DataNascimento;
                usuario.Telefone = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Telefone;
                usuario.Cep = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Cep;
                usuario.Endereco = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Endereco;
                usuario.Numero = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Numero;
                usuario.Complemento = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Complemento;
                usuario.Bairro = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Bairro;
                usuario.Cidade = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Cidade;
                usuario.Uf = usuario.UsuariosDtos.FirstOrDefault(x => x.Codigo == codigo).Uf;
            }

            return View(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigo, string nome, string email, string senha, int codigoTipoUsuario, string cpf, DateTime dataNascimento, string telefone, int cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf)
        {
            try
            {
                if (codigo != 0)
                {
                    var dados = new UsuariosDto
                    {
                        Codigo = codigo,
                        Nome = nome,
                        Email = email,
                        Senha = senha,
                        Tipo = codigoTipoUsuario,
                        Cpf = cpf,
                        DataNascimento = dataNascimento,
                        Telefone = telefone ,
                        Cep = cep ,
                        Endereco = endereco ,
                        Numero = numero,
                        Complemento = complemento,
                        Bairro = bairro,
                        Cidade = cidade ,
                        Uf = uf
                    };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PutAsync("https://localhost:5001/api/usuario/" + codigo, httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Funcionario alterado com sucesso!";
                            }
                        }
                    }
                }
                else
                {
                    var dadosLogin = new Usuario { Nome = nome, Email = email, Senha = senha, Tipo = codigoTipoUsuario };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dadosLogin), Encoding.UTF8, "application/json");
                    int codigoUsuario = 0;

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {

                        using (var response = await httpClient.PostAsync("https://flysneakersbeapi.azurewebsites.net/api/usuario", httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            usuarioLogado = JsonConvert.DeserializeObject<UsuarioLogadoDto>(resultApi);
                            codigoUsuario = usuarioLogado.Codigo;

                        }
                        var dadosUsuario = new UsuarioDados
                        {
                            CodigoUsuario = codigoUsuario,
                            Cpf = cpf,
                            DataNascimento = dataNascimento,
                            Telefone = telefone,
                            Cep = cep,
                            Endereco = endereco,
                            Numero = numero,
                            Complemento = complemento,
                            Bairro = bairro,
                            Cidade = cidade,
                            Uf = uf,
                        };

                        var httpContentDetails = new StringContent(JsonConvert.SerializeObject(dadosUsuario), Encoding.UTF8, "application/json");

                        using (var response = await httpClient.PostAsync("https://flysneakersbeapi.azurewebsites.net/api/usuario/dados", httpContentDetails))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            var a = JsonConvert.DeserializeObject<UsuarioDados>(resultApi);
                        }

                    }
                }

                return RedirectToAction("Index", "CadastroFuncionario", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao cadastrar funcionario, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "CadastroFuncionario", new { erro = erro });
            }
        }

        public async Task<IActionResult> Editar(int codigo)
        {
            try
            {
                IEnumerable<UsuariosDto> retorno;

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var dados = new ObterUsuariosDto { TipoUsuario = new int[] { 1, 2 } };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/usuario/obter", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        retorno = JsonConvert.DeserializeObject<IEnumerable<UsuariosDto>>(resultApi);
                    }
                }

                var result = retorno.FirstOrDefault(x => x.Codigo == codigo);
                usuario.Codigo = result.Codigo;

                return RedirectToAction("Index", "CadastroFuncionario", usuario);
            }
            catch (Exception ex)
            {
                var erro = "Erro ao alterar funcionario, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "CadastroFuncionario", new { erro = erro });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int codigo)
        {
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/usuario/" + codigo))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi == "1")
                        {
                            mensagem = "Funcionario removido com sucesso!";
                        }
                    }
                }

                return RedirectToAction("Index", "CadastroFuncionario", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao remover Funcionario, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "CadastroFuncionario", new { erro = erro });
            }
        }
    }
}
