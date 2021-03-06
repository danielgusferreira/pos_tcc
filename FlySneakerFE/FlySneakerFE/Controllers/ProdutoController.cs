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
        private ProdutosCreateDto produtosCreateDto = new ProdutosCreateDto { ProdutoDadosList = new List<ProdutoDados> { }, ProdutoList = new List<Produto> { }, Produto = new Produto { }, ProdutoDados = new ProdutoDados { } };
        private ProdutoDetalhesDto produtoDetalhes = new ProdutoDetalhesDto { Comentarios = null };
        private string mensagem = "";

        public ProdutoController(ILogger<HomeController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Create(int codigo, string mensagem, string erro, string desc = "")
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
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/produtos/criacao"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    produtosCreateDto.ProdutoList = JsonConvert.DeserializeObject<IEnumerable<Produto>>(resultApi);
                }

                using (var response = await httpClient.GetAsync("https://localhost:5001/api/marca"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    produtosCreateDto.Marcas = JsonConvert.DeserializeObject<IEnumerable<Marcas>>(resultApi);
                }

                using (var response = await httpClient.GetAsync("https://localhost:5001/api/categoria"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    produtosCreateDto.Categorias = JsonConvert.DeserializeObject<IEnumerable<Categorias>>(resultApi);
                }
            }

            if (codigo != 0)
            {
                produtosCreateDto.Produto.Codigo = codigo;
                produtosCreateDto.Produto.Nome = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).Nome;
                produtosCreateDto.Produto.Descricao = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).Descricao;
                produtosCreateDto.Produto.CodigoCategoria = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).CodigoCategoria;
                produtosCreateDto.Produto.CodigoMarca = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).CodigoMarca;
                produtosCreateDto.Produto.LinkFoto1 = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).LinkFoto1;
                produtosCreateDto.Produto.LinkFoto2 = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).LinkFoto2;
                produtosCreateDto.Produto.LinkFoto3 = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).LinkFoto3;
                produtosCreateDto.Produto.LinkFoto4 = produtosCreateDto.ProdutoList.FirstOrDefault(x => x.Codigo == codigo).LinkFoto4;
            }

            return View(produtosCreateDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(int codigo, string nome, string descricao)
        {
            try
            {

                if (codigo != 0)
                {
                    var dados = new Marcas { Codigo = codigo, Nome = nome, Descricao = descricao };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PutAsync("https://localhost:5001/api/marca/" + codigo, httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Marca alterada com sucesso!";
                            }
                        }
                    }
                }
                else
                {
                    var dados = new Marcas { Nome = nome, Descricao = descricao };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PostAsync("https://localhost:5001/api/marca", httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Marca cadastrada com sucesso!";
                            }
                        }
                    }
                }

                return RedirectToAction("Index", "Marca", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao cadastrar marca, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "Marca", new { erro = erro });
            }
        }

        public async Task<IActionResult> Editar(int codigo)
        {
            try
            {
                IEnumerable<Produto> retorno;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.GetAsync("https://localhost:5001/api/produtos/criacao"))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        retorno = JsonConvert.DeserializeObject<IEnumerable<Produto>>(resultApi);
                    }
                }

                var result = retorno.FirstOrDefault(x => x.Codigo == codigo);

                produtosCreateDto.Produto = new Produto();
                produtosCreateDto.Codigo = result.Codigo;

                return RedirectToAction("Create", "Produto", produtosCreateDto);
            }
            catch (Exception ex)
            {
                var erro = "Erro ao alterar marca, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "Marca", new { erro = erro });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int codigo)
        {
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/marca/" + codigo))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi == "1")
                        {
                            mensagem = "Marca removida com sucesso!";
                        }
                    }
                }

                return RedirectToAction("Index", "Marca", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao remover marca, verifique a existencia de algum produto vinculado a marca!";
                return RedirectToAction("Index", "Marca", new { erro = erro });
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

                        produtoDetalhes = JsonConvert.DeserializeObject<ProdutoDetalhesDto>(resultApi);
                    }

                    string urlComentario = "https://localhost:5001/api/comentario/" + codigo;

                    using (var response = await httpClient.GetAsync(urlComentario))
                    {
                        var resultComentApi = await response.Content.ReadAsStringAsync();

                        produtoDetalhes.Comentarios = JsonConvert.DeserializeObject<IEnumerable<ComentarioDto>>(resultComentApi);
                    }

                    string codigoUsuario = Request.Cookies["CodigoUsuarioLogado"] ?? "0";
                    string urlVerificar = "https://localhost:5001/api/comentario/" + codigo + "/verificar/" + codigoUsuario;

                    using (var response = await httpClient.GetAsync(urlVerificar))
                    {
                        var resultVerificarApi = await response.Content.ReadAsStringAsync();

                        produtoDetalhes.HabilitarComentario = Convert.ToBoolean(resultVerificarApi);
                    }
                }

                return View(produtosCreateDto);
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
