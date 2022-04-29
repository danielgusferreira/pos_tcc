using FlySneakerFE.Models;
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
    public class MenuController : Controller
    {
        HttpClientHandler httpClientHandler = new HttpClientHandler();

        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                //ViewBag.PerfilUsuario = Request.Cookies["PerfilUsuarioLogado"];

                //using (var httpClient = new HttpClient(httpClientHandler))
                //{
                //    using (var response = await httpClient.GetAsync("https://localhost:5001/api/produtos"))
                //    {
                //        var resultApi = await response.Content.ReadAsStringAsync();

                //        produtos = JsonConvert.DeserializeObject<IEnumerable<ProdutoPagInicialDto>>(resultApi);
                //    }
                //}

                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
