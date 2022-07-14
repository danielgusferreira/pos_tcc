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
    public class ProdutoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<HomeController> _logger;
        private ProdutoDetalhesDto produto = new ProdutoDetalhesDto { Comentarios = null };

        public ProdutoController(ILogger<HomeController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                return View();
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> Details(int codigo)
        {
            try
            {
                ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    string url = "https://flysneakersbeapi.azurewebsites.net/api/produtos/" + codigo;

                    using (var response = await httpClient.GetAsync(url))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        produto = JsonConvert.DeserializeObject<ProdutoDetalhesDto>(resultApi);
                    }

                    string urlComentario = "https://localhost:5001/api/comentario/" + codigo;

                    using (var response = await httpClient.GetAsync(urlComentario))
                    {
                        var resultComentApi = await response.Content.ReadAsStringAsync();

                        produto.Comentarios = JsonConvert.DeserializeObject<IEnumerable<ComentarioDto>>(resultComentApi);
                    }

                    string codigoUsuario = Request.Cookies["CodigoUsuarioLogado"] ?? "0";
                    string urlVerificar = "https://localhost:5001/api/comentario/" + codigo + "/verificar/" + codigoUsuario;

                    using (var response = await httpClient.GetAsync(urlVerificar))
                    {
                        var resultVerificarApi = await response.Content.ReadAsStringAsync();

                        produto.HabilitarComentario = Convert.ToBoolean(resultVerificarApi);
                    }
                }

                return View(produto);
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(string codigoProdutoDados, int quantidade)
        {
            try
            {
                if (Request.Cookies["CodigoUsuarioLogado"] != null)
                {
                    var dados = new CadastrarCarrinhoDto
                    {
                        CodigoProdutoDados = Convert.ToInt32(codigoProdutoDados),
                        Quantidade = quantidade,
                        UsuarioCodigo = Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"])
                    };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PostAsync("https://flysneakersbeapi.azurewebsites.net/api/carrinho/", httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi != "1")
                            {
                                var a = "";
                            }
                        }
                    }

                }
                else
                {
                    return RedirectToAction("Login", "Login");
                }

                return RedirectToAction("Index", "Carrinho");
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Comentario(int codigo, string nota, string comentario)
        {
            try
            {
                var dados = new ComentarioDto
                {
                    CodigoProduto = codigo,
                    Nota = Convert.ToInt32(nota),
                    Descricao = comentario,
                    CodigoUsuario = Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"])
                };

                var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.PostAsync("https://localhost:5001/api/comentario/", httpContent))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi != "1")
                        {
                            var a = "";
                        }
                    }
                }
                return RedirectToAction("Details", "Produto");
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar cadastro, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }
    }
}
