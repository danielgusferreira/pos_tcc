using FlySneakerFE.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FlySneakerFE.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class CategoryViewComponent : ViewComponent
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();
        private IEnumerable<Categorias> categorias = null;
        private IEnumerable<Marcas> marcas = null;


        public CategoryViewComponent()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    await ObterCategorias(httpClient);
                    await ObterMarcas(httpClient);
                }

                var result = new MenuDto { Categorias = categorias, Marcas = marcas };

                return View("Index", result);
            }
            catch
            {
                return null;
            }
        }

        private async Task ObterCategorias(HttpClient httpClient)
        {

            using (var response = await httpClient.GetAsync("https://flysneakersbeapi.azurewebsites.net/api/categoria"))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

                categorias = JsonConvert.DeserializeObject<IEnumerable<Categorias>>(resultApi);
            }
        }


        private async Task ObterMarcas(HttpClient httpClient)
        {
            using (var response = await httpClient.GetAsync("https://flysneakersbeapi.azurewebsites.net/api/marca"))
            {
                var resultApi = await response.Content.ReadAsStringAsync();

                marcas = JsonConvert.DeserializeObject<IEnumerable<Marcas>>(resultApi);
            }
        }
    }
}

