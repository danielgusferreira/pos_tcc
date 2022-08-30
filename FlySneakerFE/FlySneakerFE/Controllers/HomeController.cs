using FlySneakerFE.Models;
using FlySneakerFE.Service;
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
        public async Task<IActionResult> Index(int codigoMarca, int codigoCategoria, bool pedido = false)
        {
            try
            {
                ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];

                if (Request.Cookies["PerfilUsuarioLogado"] == "1" || Request.Cookies["PerfilUsuarioLogado"] == "2")
                {
                    return RedirectToAction("IndexAdm");
                }

                
                ViewBag.PedidoRealizado = pedido;

                using (var httpClient = new HttpClient(httpClientHandler))
                {

                    var url = "https://flysneakersbeapi.azurewebsites.net/api/produtos";

                    if(codigoCategoria != 0)
                        url += "?codigoCategoria=" + codigoCategoria;

                    if (codigoMarca != 0)
                        url += "?codigoMarca=" + codigoMarca;

                    using (var response = await httpClient.GetAsync(url))
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

        [HttpGet]
        public async Task<IActionResult> IndexAdm(int codigoMarca, int codigoCategoria, bool pedido = false)
        {
            try
            {
                ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];

                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }

        }

        public async Task<JsonResult> GraficoVendasAnual()
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                var url = "https://flysneakersbeapi.azurewebsites.net/api/pedido/graficos";

                using (var response = await httpClient.GetAsync(url))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    var dados = JsonConvert.DeserializeObject<GraficoDto>(resultApi);

                    var listaPopulacao = PopulacaoService.GetPopulacaoPorEstado(dados.ListaGraficoVendasAnual);

                    return Json(listaPopulacao);
                }
            }
        }

        public async Task<JsonResult> GraficoVendasPorMarca()
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                var url = "https://flysneakersbeapi.azurewebsites.net/api/pedido/graficos";

                using (var response = await httpClient.GetAsync(url))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    var dados = JsonConvert.DeserializeObject<GraficoDto>(resultApi);

                    var listaPopulacao = PopulacaoService.GetPopulacaoPorEstado(dados.ListaGraficoVendasPorMarca);

                    return Json(listaPopulacao);
                }
            }
        }

        public async Task<JsonResult> GraficoVendasPorCategoria()
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
                var url = "https://flysneakersbeapi.azurewebsites.net/api/pedido/graficos";

                using (var response = await httpClient.GetAsync(url))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    var dados = JsonConvert.DeserializeObject<GraficoDto>(resultApi);

                    var listaPopulacao = PopulacaoService.GetPopulacaoPorEstado(dados.ListaGraficoVendasPorCategoria);

                    return Json(listaPopulacao);
                }
            }
        }

        public async Task<JsonResult> GraficoQuantidadeVendasPorMes()
        {
            using (var httpClient = new HttpClient(httpClientHandler))
            {
               var url = "https://flysneakersbeapi.azurewebsites.net/api/pedido/graficos";

                using (var response = await httpClient.GetAsync(url))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    var dados = JsonConvert.DeserializeObject<GraficoDto>(resultApi);

                    var listaPopulacao = PopulacaoService.GetPopulacaoPorEstado(dados.ListaGraficoQuantidadeVendasPorMes);

                    return Json(listaPopulacao);
                }
            }
        }
    }
}
