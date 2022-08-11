using FlySneakerFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlySneakerFE.ViewComponents
{
    [ViewComponent(Name = "Dados")]
    public class CreateDadosViewComponent : ViewComponent
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private MarcasDto marca = new MarcasDto { Marcas = null };

        public CreateDadosViewComponent()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IViewComponentResult> InvokeAsync(int codigoProduto, int codigo, string mensagem, string erro, string desc = "")
        {
            ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];
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
    }
}

