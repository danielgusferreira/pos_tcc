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
    public class MarcaController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<MarcaController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();
        private MarcasDto marca = new MarcasDto { Marcas = null };
        private string mensagem = "";

        public MarcaController(ILogger<MarcaController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index(int codigo, string mensagem, string erro, string desc = "")
        {
            if(Request.Cookies["PerfilUsuarioLogado"] != "1" || Request.Cookies["PerfilUsuarioLogado"] != "2")
            {
                RedirectToAction("Index", "Home");
            }

            ViewBag.Mensagem = mensagem;
            ViewBag.Erro = erro;

            using (var httpClient = new HttpClient(httpClientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/marca"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    marca.Marcas = JsonConvert.DeserializeObject<IEnumerable<Marcas>>(resultApi);
                }
            }

            if (codigo != 0)
            {
                marca.Codigo = codigo;
                marca.Nome = marca.Marcas.FirstOrDefault(x => x.Codigo == codigo).Nome;
                marca.Descricao = marca.Marcas.FirstOrDefault(x => x.Codigo == codigo).Descricao;
            }

            return View(marca);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigo, string nome, string descricao)
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

                return RedirectToAction("Index", "Marca", new {mensagem = mensagem });
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
                IEnumerable<Marcas> retorno;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.GetAsync("https://localhost:5001/api/marca"))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        retorno = JsonConvert.DeserializeObject<IEnumerable<Marcas>>(resultApi);
                    }
                }

                var result = retorno.FirstOrDefault(x => x.Codigo == codigo);

                marca.Codigo = result.Codigo;

                return RedirectToAction("Index", "Marca", marca);
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
                    using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/marca/"+ codigo))
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
    }
}
