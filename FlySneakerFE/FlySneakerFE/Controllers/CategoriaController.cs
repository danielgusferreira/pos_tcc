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
        private CategoriasDto categoria = new CategoriasDto { Categorias = null };
        private string mensagem = "";

        public CategoriaController(ILogger<CategoriaController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index(int codigo, string mensagem, string erro, string desc = "")
        {
            if(Request.Cookies["PerfilUsuarioLogado"] != "1" && Request.Cookies["PerfilUsuarioLogado"] != "2")
            {
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];
            ViewBag.Mensagem = mensagem;
            ViewBag.Erro = erro;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/categoria"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    categoria.Categorias = JsonConvert.DeserializeObject<IEnumerable<Categorias>>(resultApi);
                }
            }

            if (codigo != 0)
            {
                categoria.Codigo = codigo;
                categoria.Nome = categoria.Categorias.FirstOrDefault(x => x.Codigo == codigo).Nome;
                categoria.Descricao = categoria.Categorias.FirstOrDefault(x => x.Codigo == codigo).Descricao;
            }

            return View(categoria);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigo, string nome, string descricao)
        {
            try
            {

                if (codigo != 0)
                {
                    var dados = new Categorias { Codigo = codigo, Nome = nome, Descricao = descricao };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PutAsync("https://localhost:5001/api/categoria/" + codigo, httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Categoria alterada com sucesso!";
                            }
                        }
                    }
                }
                else
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
                                mensagem = "Categoria cadastrada com sucesso!";
                            }
                        }
                    }
                }

                return RedirectToAction("Index", "Categoria", new {mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao cadastrar categoria, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "Categoria", new { erro = erro });
            }
        }

        public async Task<IActionResult> Editar(int codigo)
        {
            try
            {
                IEnumerable<Categorias> retorno;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.GetAsync("https://localhost:5001/api/categoria"))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        retorno = JsonConvert.DeserializeObject<IEnumerable<Categorias>>(resultApi);
                    }
                }

                var result = retorno.FirstOrDefault(x => x.Codigo == codigo);

                categoria.Codigo = result.Codigo;

                return RedirectToAction("Index", "Categoria", categoria);
            }
            catch (Exception ex)
            {
                var erro = "Erro ao alterar categoria, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "Categoria", new { erro = erro });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int codigo)
        {
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/categoria/"+ codigo))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi == "1")
                        {
                            mensagem = "Categoria removida com sucesso!";
                        }
                    }
                }

                return RedirectToAction("Index", "Categoria", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao remover categoria, verifique a existencia de algum produto vinculado a categoria!";
                return RedirectToAction("Index", "Categoria", new { erro = erro });
            }
        }
    }
}
