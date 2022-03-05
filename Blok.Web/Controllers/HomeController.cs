using Blok.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blok.Web.Controllers
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
            var id = HttpContext.Session.Id;
            Random random = new Random();
            
            HttpContext.Session.SetString("name", random.Next(100).ToString());
            ViewData["sessionID"] = id.ToString();
            ViewData["name"] = HttpContext.Session.GetString("name");
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
    }
}