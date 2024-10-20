using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Online_IT_Preparation.Models;
using System.Diagnostics;

namespace Online_IT_Preparation.Controllers
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
        


    }
}
