using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleMVCWeatherApp.Models;
using System.Net.Http;

namespace SampleMVCWeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var result = await GetWeather();
            return View();
        }

        public async Task<ActionResult> GetWeather()
        {
            HttpClient client = new HttpClient();
            var url = "https://www.wroclaw.pl/open-data/api/action/datastore_search?resource_id=f55a87ee-08c8-4458-96c2-daed0e32f587&limit=5&sort=_id%20desc";
            return await Get(url);
        }

        [HttpGet]
        public async Task<ActionResult> Get(string url)
        {
            var client = _clientFactory.CreateClient();

            var result = await client.GetStringAsync(url);
            Console.WriteLine(result);

            return Ok(result);
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
    }
}
