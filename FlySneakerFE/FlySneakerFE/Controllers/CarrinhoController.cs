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
    public class CarrinhoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<CarrinhoController> _logger;
        private IEnumerable<DadosCarrinhoDto> carrinho = null;

        public CarrinhoController(ILogger<CarrinhoController> logger)
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
                    string url = "https://localhost:5001/api/carrinho/" + Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"]);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        carrinho = JsonConvert.DeserializeObject<IEnumerable<DadosCarrinhoDto>>(resultApi);
                    }
                }

                return View(carrinho);
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(int usu)
        {

            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    string url = "https://localhost:5001/api/usuario/dados/" + Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"]);

                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (await response.Content.ReadAsStringAsync() == "0")
                        {
                            return RedirectToAction("Details", "Cadastrar");
                        }
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
