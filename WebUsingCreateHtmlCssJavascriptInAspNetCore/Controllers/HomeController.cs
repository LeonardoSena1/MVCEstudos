using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUsingCreateHtmlCssJavascriptInAspNetCore.Models;

namespace WebUsingCreateHtmlCssJavascriptInAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Teste()
        {

            return View(new CepModel());
        }

        [HttpPost]
        public IActionResult Teste(CepModel model)
        {
            var client = new RestClient(string.Concat("https://viacep.com.br/ws/", model.cep, "/json/"));
            client.Timeout = -1;
            client.FollowRedirects = false;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return View(JsonConvert.DeserializeObject<CepModel>(response.Content));
        }
    }
}
