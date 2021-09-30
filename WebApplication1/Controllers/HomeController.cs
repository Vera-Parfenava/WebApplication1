using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

    }
}
