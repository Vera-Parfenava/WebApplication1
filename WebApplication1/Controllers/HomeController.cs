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
        public IActionResult Status(string Code) => Content($"Status code - {Code}.");




    }
}
