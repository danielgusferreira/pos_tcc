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
    public class CategoriaController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<CategoriaController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();
        private IEnumerable<Categorias> categorias = null;

        public CategoriaController(ILogger<CategoriaController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if(Request.Cookies["PerfilUsuarioLogado"] != "1" || Request.Cookies["PerfilUsuarioLogado"] != "2")
            {
                RedirectToAction("Index", "Home");
            }

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/categoria"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    categorias = JsonConvert.DeserializeObject<IEnumerable<Categorias>>(resultApi);
                }
            }

            return View(categorias);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nome, string descricao)
        {
            try
            {
                var dados = new Categorias { Nome = nome, Descricao = descricao };

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/categoria", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi == "1")
                        {
                            ViewBag.Inserido = true;
                        }
                    }
                }

                return RedirectToAction("Index", "Categoria");
            }
            catch (Exception ex)
            {
                ViewBag.ErroLogin = "Erro ao realizar login, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }
    }
}
