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
        private ProdutosCreateDto produtosCreateDto = new ProdutosCreateDto { ProdutoDadosList = new List<ProdutoDados> { }, ProdutoList = new List<Produto> { }, Produto = new Produto { }, ProdutoDados = new ProdutoDados { } };

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
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/produtos/criacao-dados/" + codigoProduto))
                {
                    var resultApi = await response.Content.ReadAsStringAsync();

                    produtosCreateDto.ProdutoDadosList = JsonConvert.DeserializeObject<IEnumerable<ProdutoDados>>(resultApi);
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
    }
}

