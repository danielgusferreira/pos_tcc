using FlySneakerFE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlySneakerFE.Controllers
{
    public class HomeController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<HomeController> _logger;
        private IEnumerable<ProdutoPagInicialDto> produtos = null;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.GetAsync("https://localhost:5001/api/produtos"))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        produtos = JsonConvert.DeserializeObject<IEnumerable<ProdutoPagInicialDto>>(resultApi);
                    }
                }

                return View(produtos);
            }
            catch (Exception ex)
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }

        }

    }
}
