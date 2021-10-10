using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult About() => View();
        public IActionResult Catalog() => View();
        public IActionResult ContactUs() => View();

        public IActionResult Status(string id)
        {
            switch (id)
            {
                default: return Content($"Status --{id}");
                case "404": return View("Error404");
            }
        }
    }
}
