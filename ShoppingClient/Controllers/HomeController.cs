using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShoppingClient.Data;
using ShoppingClient.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShoppingClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;

        public HomeController(ILogger<HomeController> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClient = httpClientFactory.CreateClient("ShoppingApiClient");
        }

        public async Task<IActionResult> Index()
        {
            var response =await  _httpClient.GetAsync("/product");
            var result = await response.Content.ReadAsStringAsync();
            IEnumerable <Product> products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result);
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
            //Testing autobuild
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
