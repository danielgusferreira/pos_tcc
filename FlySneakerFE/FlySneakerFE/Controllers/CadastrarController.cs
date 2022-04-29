using FlySneakerFE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FlySneakerFE.Controllers
{
    public class CadastrarController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<CadastrarController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();
        private UsuarioDados usuarioDados = new UsuarioDados();

        public CadastrarController(ILogger<CadastrarController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nome, string email, string senha, string confirmarSenha)
        {
            try
            {
                var dados = new Usuario { Nome = nome, Email = email, Senha = senha };

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/usuario", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        usuarioLogado = JsonConvert.DeserializeObject<UsuarioLogadoDto>(resultApi);

                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(30);
                        Response.Cookies.Append("CodigoUsuarioLogado", usuarioLogado.Codigo.ToString(), options);
                        Response.Cookies.Append("EmailUsuarioLogado", usuarioLogado.Email, options);
                        Response.Cookies.Append("NomeUsuarioLogado", usuarioLogado.Nome, options);
                        Response.Cookies.Append("PerfilUsuarioLogado", usuarioLogado.Perfil.ToString(), options);
                    }
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Details(string cpf, DateTime dataNascimento, string telefone, int cep, string endereco, string numero, string complemento, string bairro, string cidade, string uf)
        {
            try
            {
                var dados = new UsuarioDados
                {
                    CodigoUsuario = Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"]),
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

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/usuario/dados", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        usuarioDados = JsonConvert.DeserializeObject<UsuarioDados>(resultApi);
                    }
                }

                return RedirectToAction("Index", "Pedido");
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }
    }
}