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
    public class LoginController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<LoginController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();


        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            try
            {
                var dados = new LoginDto { Email = email, Senha = senha };

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://flysneakersbeapi.azurewebsites.net/api/usuario/login", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        dynamic data = JObject.Parse(resultApi);

                        if(data.status == 404)
                        {
                            ViewBag.ErroLogin = "Login e senha inválidos, tente novamente!";
                            return View();
                        }

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
            catch (Exception ex)
            {
                ViewBag.ErroLogin = "Erro ao realizar login, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Sair()
        {
            Response.Cookies.Delete("EmailUsuarioLogado");
            Response.Cookies.Delete("NomeUsuarioLogado");
            Response.Cookies.Delete("PerfilUsuarioLogado");

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
