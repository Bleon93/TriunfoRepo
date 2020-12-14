using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Triunfo.Web.Models;

namespace Triunfo.Web.Controllers
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

        public IActionResult Productos()
        {
            return View();
        }

        public IActionResult Contactenos()
        {
            return View();
        }

        public IActionResult QuienesSomos()
        {
            return View();
        }

        public IActionResult Registrarse()
        {
            return View();
        }

        public IActionResult Ingresar()
        {
            return View();
        }

        public IActionResult OlvidoContraseña()
        {
            return View();
        }

        public IActionResult MenuListar()
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
