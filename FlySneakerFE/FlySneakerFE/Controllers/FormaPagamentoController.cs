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
    public class FormaPagamentoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<FormaPagamentoController> _logger;
        private UsuarioLogadoDto usuarioLogado = new UsuarioLogadoDto();
        private FormaPagamentosDto formaPagamento = new FormaPagamentosDto { MeioPagamento = null };
        private string mensagem = "";

        public FormaPagamentoController(ILogger<FormaPagamentoController> logger)
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
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/meio-pagamento"))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    formaPagamento.MeioPagamento = JsonConvert.DeserializeObject<IEnumerable<MeioPagamento>>(resultApi);
                }
            }

            if (codigo != 0)
            {
                formaPagamento.Codigo = codigo;
                formaPagamento.Nome = formaPagamento.MeioPagamento.FirstOrDefault(x => x.Codigo == codigo).Nome;
                formaPagamento.Descricao = formaPagamento.MeioPagamento.FirstOrDefault(x => x.Codigo == codigo).Descricao;
            }

            return View(formaPagamento);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigo, string nome, string descricao)
        {
            try
            {

                if (codigo != 0)
                {
                    var dados = new MeioPagamento { Codigo = codigo, Nome = nome, Descricao = descricao };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PutAsync("https://localhost:5001/api/meio-pagamento/" + codigo, httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Forma Pagamento alterada com sucesso!";
                            }
                        }
                    }
                }
                else
                {
                    var dados = new MeioPagamento { Nome = nome, Descricao = descricao };

                    var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

                    using (var httpClient = new HttpClient(httpClientHandler))
                    {
                        using (var response = await httpClient.PostAsync("https://localhost:5001/api/meio-pagamento", httpContent))
                        {
                            var resultApi = await response.Content.ReadAsStringAsync();

                            if (resultApi == "1")
                            {
                                mensagem = "Forma Pagamento cadastrada com sucesso!";
                            }
                        }
                    }
                }

                return RedirectToAction("Index", "FormaPagamento", new {mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao cadastrar formaPagamento, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "FormaPagamento", new { erro = erro });
            }
        }

        public async Task<IActionResult> Editar(int codigo)
        {
            try
            {
                IEnumerable<MeioPagamento> retorno;
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.GetAsync("https://localhost:5001/api/meio-pagamento"))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        retorno = JsonConvert.DeserializeObject<IEnumerable<MeioPagamento>>(resultApi);
                    }
                }

                var result = retorno.FirstOrDefault(x => x.Codigo == codigo);

                formaPagamento.Codigo = result.Codigo;

                return RedirectToAction("Index", "FormaPagamento", formaPagamento);
            }
            catch (Exception ex)
            {
                var erro = "Erro ao alterar formaPagamento, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return RedirectToAction("Index", "FormaPagamento", new { erro = erro });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Excluir(int codigo)
        {
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/meio-pagamento/" + codigo))
                    {
                        var resultApi = await response.Content.ReadAsStringAsync();

                        if (resultApi == "1")
                        {
                            mensagem = "Forma Pagamento removida com sucesso!";
                        }
                    }
                }

                return RedirectToAction("Index", "FormaPagamento", new { mensagem = mensagem });
            }
            catch
            {
                var erro = "Erro ao remover formaPagamento, verifique a existencia de algum produto vinculado a formaPagamento!";
                return RedirectToAction("Index", "FormaPagamento", new { erro = erro });
            }
        }
    }
}
