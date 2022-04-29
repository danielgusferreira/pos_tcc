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
    public class PedidoController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<PedidoController> _logger;
        private UsuarioDados usuario = null;
        private IEnumerable<MeioPagamento> meiosPagamento = null;
        private IEnumerable<DadosCarrinhoDto> carrinho = null;


        public PedidoController(ILogger<PedidoController> logger)
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
                    await ObterDadosUsuario(httpClient);
                    await ObterDadosMeiosPagamento(httpClient);
                    await ObterCarrinho(httpClient);
                }

                var ValorCarrinho = carrinho.Select(x => x.Quantidade * x.Valor).Sum();
                var CodigosCarrinhos = carrinho.Select(x => x.Codigo);

                var dadosPedido = new ConfirmarPedidoDto { MeioPagamento = meiosPagamento, UsuarioDados = usuario, ValorPedido = ValorCarrinho, Codigos = CodigosCarrinhos };

                return View(dadosPedido);

            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao buscar pedido, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(int codigoMeioPagamento)
        {
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    await ObterCarrinho(httpClient);

                    var codCarrinhos = carrinho.Select(x => x.Codigo);

                    await FinalizarPedido(httpClient, codigoMeioPagamento, codCarrinhos);
                }

                return RedirectToAction("Index", "Pedido");
            }
            catch
            {
                ViewBag.ErroLogin = "Erro ao realizar pedido, caso o erro persista tente mais tarde ou entre em contato com o suporte!";
                return View();
            }
        }

        private async Task ObterDadosUsuario(HttpClient httpClient)
        {
            string url = "https://localhost:5001/api/usuario/dados/" + Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"]);

            using (var response = await httpClient.GetAsync(url))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

                usuario = JsonConvert.DeserializeObject<UsuarioDados>(resultApi);
            }

        }

        private async Task ObterDadosMeiosPagamento(HttpClient httpClient)
        {
            string url = "https://localhost:5001/api/meio-pagamento";

            using (var response = await httpClient.GetAsync(url))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

                meiosPagamento = JsonConvert.DeserializeObject<IEnumerable<MeioPagamento>>(resultApi);
            }
        }

        private async Task ObterCarrinho(HttpClient httpClient)
        {
            string url = "https://localhost:5001/api/carrinho/" + Convert.ToInt32(Request.Cookies["CodigoUsuarioLogado"]);

            using (var response = await httpClient.GetAsync(url))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

                carrinho = JsonConvert.DeserializeObject<IEnumerable<DadosCarrinhoDto>>(resultApi);
            }
        }

        private async Task FinalizarPedido(HttpClient httpClient, int codigoMeioPagamento, IEnumerable<int> codCarrinhos)
        {
            var dados = new CadastrarPedidoDto { CodPagamento = codigoMeioPagamento, CodCarrinhos = codCarrinhos };

            var httpContent = new StringContent(JsonConvert.SerializeObject(dados), Encoding.UTF8, "application/json");

            using (var response = await httpClient.PostAsync("https://localhost:5001/api/usuario/login", httpContent))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

            }

        }
    }
}
